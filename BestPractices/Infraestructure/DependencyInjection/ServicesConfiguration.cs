using Best_Practices.Infraestructure.Factories;
using Best_Practices.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Best_Practices.Infraestructure.DependencyInjection
{
    public class ServicesConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Registrar el repositorio como Singleton para persistir los datos en memoria entre peticiones
            services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();

            // Registrar todas las fábricas concretas (Factory Method)
            services.AddTransient<Creator, FordMustangCreator>();
            services.AddTransient<Creator, FordExplorerCreator>();
            services.AddTransient<Creator, FordEscapeCreator>();
        }
    }
}
