using OpenQA.Selenium.Chrome;

namespace TemplateFramework.Settings
{
    public class BrowserOptions
    {
        public BrowserOptions(WebDriverSettings settings)
        {
            WebDriverSettings = settings;
        }

        private WebDriverSettings WebDriverSettings { get; }

        public ChromeOptions Chrome()
        {
            var options = new ChromeOptions();

            if (WebDriverSettings.Headless)
            {
                options.AddArgument("--headless");
            }

            return options;
        }
    }
}
