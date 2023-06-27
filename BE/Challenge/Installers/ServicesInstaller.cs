using PRJ.Repository.Repositories;
using PRJ.Repository.UnitOfWorks;
using PRJ.Service.AutoMapper;
using PRJ.Service.Services.CategoryServices;
using PRJ.Service.Services.ProductServices;
using PRJ.Service.Services.PurchaseServices;
using PRJ.Service.Services.UserServices;
using PRJ.ShoppingPortal.Filters;

namespace PRJ.API.Installers;
public class ServicesInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ExceptionHandling>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(AutoMapperProfiles));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IProductService, ProductService>();
		services.AddScoped<ICategoryService, CategoryService>();
		services.AddScoped<IPurchaseService, PurchaseService>();
	}
}
