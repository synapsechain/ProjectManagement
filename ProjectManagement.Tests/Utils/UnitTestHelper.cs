using System;
using AutoMapper;
using ProjectManagement.Api.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectManagement.Api.Data;

namespace ProjectManagement.Tests.Utils
{
    public static class UnitTestHelper
    {
        public static void InMemoryContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            builder
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) //ensure that we have new db everytime
                .ConfigureWarnings(y => y.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }

        public static DbContextOptions<AppDbContext> CreateInMemoryDb()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            InMemoryContextOptionsBuilder(builder);
            return builder.Options;
        }

        public static IMapper Mapper { get; }
            = new Mapper(new MapperConfiguration(x => x.AddProfile<MapperProfile>())); 
    }
}
