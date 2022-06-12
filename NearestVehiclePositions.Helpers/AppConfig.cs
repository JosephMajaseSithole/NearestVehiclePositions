using Microsoft.Extensions.Configuration;

namespace NearestVehiclePositions.Helpers
{
    public static class AppConfig
    {
        public static string GetDataFilePath()
        {
            return GetConfiguration().GetSection("AppSettings").GetSection("DataFilePath").Value;
        }

        private static IConfigurationRoot GetConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            return configuration;
        }
    }
}
