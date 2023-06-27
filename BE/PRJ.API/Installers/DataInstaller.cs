namespace PRJ.API.Installers;
public class DataInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
		var connectionString = configuration.GetSection("ASPNETCORE_ENVIRONMENT").GetValue<string>("running_Environment") == ApplicationConstants.Development
						? configuration.GetConnectionString(ApplicationConstants.Development)
						: configuration.GetConnectionString(ApplicationConstants.Production);

		services.AddDbContext<MainContext>(opt => opt.UseSqlServer(connectionString));

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
		services.AddCors();
        services.AddControllers(options =>
        {
            var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
            options.Filters.Add(new AuthorizeFilter(policy));
        })
                   .AddJsonOptions(
                       options =>
                       {
                           options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                           options.JsonSerializerOptions.PropertyNamingPolicy = null;
                           options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                           options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                       });
    }
}
