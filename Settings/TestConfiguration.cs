using Microsoft.Extensions.Configuration;
using System.IO;
using TemplateFramework.Helpers;

namespace TemplateFramework.Settings
{
    public class TestConfiguration
    {
        public static EnvironmentSettings EnvSettings =>
            LoadConfiguration().GetSection("environment").Get<EnvironmentSettings>();
        public static WebDriverSettings DriverSettings =>
            LoadConfiguration().GetSection("webdriver").Get<WebDriverSettings>();

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", false);

            return builder.Build();
        }
    }
}
