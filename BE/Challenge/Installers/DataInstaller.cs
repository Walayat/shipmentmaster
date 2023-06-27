using Microsoft.EntityFrameworkCore;
using PRJ.DataAccess.Context;
using PRJ.Utility;

namespace PRJ.API.Installers;
public class DataInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
		var connectionString = configuration.GetSection("ASPNETCORE_ENVIRONMENT").GetValue<string>("running_Environment") == ApplicationConstants.Development
						? configuration.GetConnectionString(ApplicationConstants.Development)
						: configuration.GetConnectionString(ApplicationConstants.Production);
		
        services.AddDbContext<MainContext>(opt => opt.UseSqlServer(connectionString));
    }
}
