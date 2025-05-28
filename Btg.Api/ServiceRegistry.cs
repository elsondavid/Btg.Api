

using Btg.Core.Services;

namespace Btg.Api;

public static class ServiceRegistry
{
    public static void AddServiceRegistry(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IClienteService, ClienteService>();
           
    }
}