using Atea.Interfaces;
using Atea.Models;
using Atea.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Dependency.Startup))]

namespace Dependency
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IAddTableData, AddTableData>();
            builder.Services.AddSingleton<IAddBlobs, AddBlobs>();
            builder.Services.AddSingleton<IImportConnection, ImportConnection>();
            builder.Services.AddSingleton<IGetBlobs, GetBlobs>();
            builder.Services.AddSingleton<ISelectTableData, SelectTableData>();
            builder.Services.AddSingleton<ISelectTableDataComponents, SelectTableDataComponents>();
            builder.Services.AddSingleton<ISelectTableDataReference, SelectTableDataReference>();
        }
    }
}