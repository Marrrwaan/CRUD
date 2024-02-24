namespace CRUD_APIs.Helpers
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public ConfigurationHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("ConnectionString");
        }
    }
}