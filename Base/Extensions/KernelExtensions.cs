using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using TemplateFramework.Base.Extensions.WebDriver;
using TemplateFramework.Helpers;

namespace TemplateFramework.Base.Extensions
{
    public static class KernelExtensions
    {
        public static IWebDriver GetDriver(this IKernel kernel)
        {
            if (kernel.GetBindings(typeof(IWebDriver)).Any()) return kernel.Get<IWebDriver>();

            var settings = TestConfiguration.DriverSettings;
            var driver = InitializeBrowser(settings);

            kernel.Bind<IWebDriver>()
                .ToMethod(_ => driver)
                .InSingletonScope();

            driver.MaximizeScreen();
            driver.Open(UrlProvider.BaseUrl);

            return driver;
        }

        public static void QuitDriver(this IKernel kernel)
        {
            var driver = kernel.Get<IWebDriver>();

            driver.Dispose();
            kernel.Unbind<IWebDriver>();
        }

        public static Pages GetPages(this IKernel kernel)
        {
            if (kernel.GetBindings(typeof(Pages)).Any()) return kernel.Get<Pages>();

            var pages = new Pages(GetDriver(kernel));

            kernel.Bind<Pages>()
                .ToMethod(_ => pages)
                .InSingletonScope();

            return pages;
        }

        private static IWebDriver InitializeBrowser(WebDriverSettings settings)
        {
            var browserOptions = new BrowserOptions(settings);
            var driverDirectory = settings.DriverDirectory
                                  ?? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return settings.Browser switch
            {
                "chrome" => new ChromeDriver(driverDirectory, browserOptions.Chrome()),
                _ => throw new NotImplementedException(
                    $"Browser '{settings.Browser}' is not supported")
            };
        }
    }
}
