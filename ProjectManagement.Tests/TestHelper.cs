using System;
using AutoMapper;
using ProjectManagement.Api.Tools;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Contexts;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ProjectManagement.Tests
{
    public static class TestHelper
    {
        public static DbContextOptions<ProjectManagementContext> ContextOptions
        {
            get => new DbContextOptionsBuilder<ProjectManagementContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) //ensure that we have new db everytime
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }

        public static IMapper Mapper
        {
            get => new Mapper(new MapperConfiguration(x => x.AddProfile<AutoMapping>()));
        }
    }
}
