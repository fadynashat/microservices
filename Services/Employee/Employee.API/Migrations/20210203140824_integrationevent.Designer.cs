﻿// <auto-generated />
using System;
using FADY.BuildingBlocks.IntegrationEventLogEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employee.API.Migrations
{
    [DbContext(typeof(IntegrationEventLogContext))]
    [Migration("20210203140824_integrationevent")]
    partial class integrationevent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FADY.BuildingBlocks.IntegrationEventLogEF.IntegrationEventLogEntry", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("EventTypeName")
                        .IsRequired();

                    b.Property<int>("State");

                    b.Property<int>("TimesSent");

                    b.Property<string>("TransactionId");

                    b.HasKey("EventId");

                    b.ToTable("IntegrationEventLog");
                });
#pragma warning restore 612, 618
        }
    }
}
