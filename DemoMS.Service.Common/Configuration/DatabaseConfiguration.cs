namespace DemoMS.Service.Common.Configuration
{
    public class DatabaseConfiguration
    {
        private readonly IConfiguration _configuration;

        public DatabaseConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("MongoDBConnection");
        }

        public (string CollectionName, string DatabaseName) GetDatabaseSettings()
        {
            var configurationSection = _configuration.GetSection("Configuration");
            return (configurationSection["CollectionName"], configurationSection["DatabaseName"]);
        }
    }
}
