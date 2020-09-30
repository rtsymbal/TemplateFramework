using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using OpenQA.Selenium;
using TemplateFramework.Base.Extensions.WebDriver;
using TemplateFramework.Models;

namespace TemplateFramework.Helpers
{
    public static class LocalStorageHelper
    {
        private const string UserDataLocalStorageItemName = "user-data";

        public static User GetUserFromLocalStorage(this IWebDriver driver)
        {
            var userData = driver.GetFromLocalStorage(UserDataLocalStorageItemName);
            return JsonConvert.DeserializeObject<User>(userData);
        }

        public static void SetUserToLocalStorage(this IWebDriver driver, User user)
        {
            var userData = JsonHelper.Serialize(user);
            driver.SetLocalStorageItem(UserDataLocalStorageItemName, userData);
        }
    }
}
