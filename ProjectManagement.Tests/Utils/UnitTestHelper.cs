using System;
using AutoMapper;
using ProjectManagement.Api.Tools;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Contexts;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

        public static DbContextOptions<ProjectManagementContext> InMemoryContextOptions
        {
            get
            {
                var builder = new DbContextOptionsBuilder<ProjectManagementContext>();
                InMemoryContextOptionsBuilder(builder);
                return builder.Options;
            }
        }

        public static IMapper Mapper
        {
            get => new Mapper(new MapperConfiguration(x => x.AddProfile<AutoMapping>()));
        }
    }
}
