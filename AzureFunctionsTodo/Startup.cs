using System;
using AzureFunctionsTodo.EntityFramework;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureFunctionsTodo.Startup))]

namespace AzureFunctionsTodo;

class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        //string connectionString = "Server=.;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=True";
        builder.Services.AddDbContext<TodoContext>(
            options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
    }
}
