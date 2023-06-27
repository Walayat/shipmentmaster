using PRJ.Service.AutoMapper;
using PRJ.Service.Services.QuotableService;
using PRJ.Service.Services.ShipmentService;
using PRJ.Service.Services.ShipperService;

namespace PRJ.API.Installers;
public class ServicesInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ExceptionHandling>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		services.AddAutoMapper(typeof(AutoMapperProfiles));
		services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IShipmentService, ShipmentService>();
        services.AddScoped<IShipperService, ShipperService>();
        services.AddScoped<IQuotableService, QuotableService>();
    }
}
