//namespace PRJ.Service.QueryHandlers;
//public static class DaperQueryExecute
//{
//	var connectionString = configuration.GetSection("ASPNETCORE_ENVIRONMENT").GetValue<string>("running_Environment") == ApplicationConstants.Development
//						? configuration.GetConnectionString(ApplicationConstants.Development)
//						: configuration.GetConnectionString(ApplicationConstants.Production);

//	public static async Task<bool> Execute(string query)
//    {
//        using (var connection = new SqlConnection(ConfigurationStrings.DBConntectionString))
//        {
//            var result = await connection.ExecuteAsync(query);
//            return true;
//        }
//    }
//    public static async Task<T> Query<T>(string query)
//	{
//        using (var connection = new SqlConnection(ConfigurationStrings.DBConntectionString))
//        {
//            var result = await connection.QueryAsync<T>(query) ;
//            return result.FirstOrDefault();
//        }
//    }

//    public static async Task<List<T>> QueryList<T>(string query)
//    {
//        using (var connection = new SqlConnection(ConfigurationStrings.DBConntectionString))
//        {
//            var result = await connection.QueryAsync<T>(query);
//            return result.ToList();
//        }
//    }
//}
