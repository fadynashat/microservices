using FADY.Services.Lookup.API.Model;
using lookup.API.Model;
using Lookup.API.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.Services.Lookup.API.Infrastructure.Repositories
{
    public class RedisLookupRepository : ILookupTRepository
    {
        private readonly ILogger<RedisLookupRepository> _logger;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public RedisLookupRepository(ILoggerFactory loggerFactory, ConnectionMultiplexer redis)
        {
            _logger = loggerFactory.CreateLogger<RedisLookupRepository>();
            _redis = redis;
            _database = redis.GetDatabase();
        }



        public IEnumerable<string> GetUsers()
        {
            var server = GetServer();
            var data = server.Keys();

            return data?.Select(k => k.ToString());
        }
      
        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());
        }

        public async Task<LookupItems> GetLookupItemAsync(string LookupName, int Code)
        {
            var data = await _database.StringGetAsync(LookupName);
            return JsonConvert.DeserializeObject<IEnumerable<LookupItems>>(data).Where(l=>l.Code== Code).FirstOrDefault();
        }

        public async Task<IEnumerable<LookupItems>> GetLookupItems(string LookupName)
        {
            var data = await _database.StringGetAsync(LookupName);

            return JsonConvert.DeserializeObject<IEnumerable<LookupItems>>(data);
        }

        public async Task<LookupItems> UpdateLookupItemAsync(string LookupName, int Code ,string Name)
        {
           
            //var created = await _database.StringSetAsync(Lookup.Name, JsonConvert.SerializeObject(Lookup));

            //if (!created)
            //{mation("Problem occur persisting the item.");
            //    return null;
            //    _logger.LogInfor
            //}

            //_logger.LogInformation("Lookup item persisted succesfully.");

            return await GetLookupItemAsync(LookupName, Code);
        }

        public async Task<bool> DeleteLookupItemAsync(string LookupName, int Code)
        {
            //get key by lookupname and code
            //insert id 
            string id = LookupName + Code;
            return await _database.KeyDeleteAsync(id);
        }
    }
}
