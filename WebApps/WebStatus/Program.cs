using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using WebStatus;
public class Program
{
    private static readonly string _namespace = typeof(Startup).Namespace;
    public static readonly string AppName = _namespace;

    private static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var config = builder.Build();

        if (config.GetValue<bool>("UseVault", false))
        {
            builder.AddAzureKeyVault(
                $"https://{config["Vault:Name"]}.vault.azure.net/",
                config["Vault:ClientId"],
                config["Vault:ClientSecret"]);
        }

        return builder.Build();
    }

    private static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
    {
        var seqServerUrl = configuration["Serilog:SeqServerUrl"];
        var logstashUrl = configuration["Serilog:LogstashgUrl"];
        return new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.WithProperty("ApplicationContext", Program.AppName)
            .Enrich.FromLogContext()
            .WriteTo.File("webstatus.log.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.Elasticsearch().WriteTo.Elasticsearch(ConfigureElasticSink(configuration, "Development"))
            .WriteTo.Seq(string.IsNullOrWhiteSpace(seqServerUrl) ? "http://seq" : seqServerUrl)
            .WriteTo.Http(string.IsNullOrWhiteSpace(logstashUrl) ? "http://logstash:8080" : logstashUrl)
            .ReadFrom.Configuration(configuration)
            .CreateLogger();


    }

    private static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, string environment)
    {
        return new ElasticsearchSinkOptions(new Uri(configuration["Serilog:ElasticConfiguration"]))
        {
            BufferCleanPayload = (failingEvent, statuscode, exception) =>
            {
                dynamic e = JObject.Parse(failingEvent);
                return JsonConvert.SerializeObject(new Dictionary<string, object>()
                {
                    { "@timestamp",e["@timestamp"]},
                    { "level","Error"},
                    { "message","Error: "+e.message},
                    { "messageTemplate",e.messageTemplate},
                    { "failingStatusCode", statuscode},
                    { "failingException", exception}
                });
            },
            MinimumLogEventLevel = LogEventLevel.Verbose,
            AutoRegisterTemplate = true,
            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
            CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true),
            IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
            EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                   EmitEventFailureHandling.WriteToFailureSink |
                                   EmitEventFailureHandling.RaiseCallback
        };
    }

    private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .CaptureStartupErrors(false)
        .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
        .UseStartup<Startup>()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseSerilog()
        .Build();

    private static void LogPackagesVersionInfo()
    {
        var assemblies = new List<Assembly>();

        foreach (var dependencyName in typeof(Program).Assembly.GetReferencedAssemblies())
        {
            try
            {
                // Try to load the referenced assembly...
                assemblies.Add(Assembly.Load(dependencyName));
            }
            catch
            {
                // Failed to load assembly. Skip it.
            }
        }

        var versionList = assemblies.Select(a => $"-{a.GetName().Name} - {GetVersion(a)}").OrderBy(value => value);

        Log.Logger.ForContext("PackageVersions", string.Join("\n", versionList)).Information("Package versions ({ApplicationContext})", Program.AppName);
    }
    private static string GetVersion(Assembly assembly)
    {
        try
        {
            return $"{assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version} ({assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.Split()[0]})";
        }
        catch
        {
            return string.Empty;
        }
    }
    public static int Main(string[] args)
    {
        var configuration = GetConfiguration();
        Log.Logger = CreateSerilogLogger(configuration);


        try
        {
            Log.Information("Configuring web host ({ApplicationContext})...", Program.AppName);
            var host = BuildWebHost(configuration, args);

            LogPackagesVersionInfo();

            Log.Information("Starting web host ({ApplicationContext})...", Program.AppName);
            host.Run();

            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", Program.AppName);
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }

    }
}