using Ninject;
using TemplateFramework.Base.Dtos;
using TemplateFramework.Base.Extensions.Rest;
using TemplateFramework.Base.Extensions.WebDriver;
using TemplateFramework.Helpers;
using TemplateFramework.Models;
using TemplateFramework.Pipeline;
using TemplateFramework.Providers;

namespace TemplateFramework.Steps
{
    public abstract class Login : StepComposition, IStep
    {
        [Inject]
        public User User { get; set; }

        public abstract void Execute();
    }

    public class DefaultLogin : Login
    {
        public override void Execute()
        {
            Driver.WaitFor(() => Driver.GetUrl().Contains(UrlProvider.BaseUrl));

            Pages.NavigationPanel.ClickLoginButton();
            Pages.LoginForm.Login(User);

            Driver.WaitFor(() => Pages.NavigationPanel.IsUserEmailDisplayed, "User login failed");

            SaveUserDataToContext();
        }

        private void SaveUserDataToContext()
        {
            var localStorageUserData = Driver.GetUserFromLocalStorage();
            User.Token = localStorageUserData.Token;
            User.Id = localStorageUserData.Id;
        }
    }

    public class FastLogin : Login
    {
        public override void Execute()
        {
            var authenticatedUser = GetAuthenticatedUser();
            SaveUserDataToContext(authenticatedUser);

            Driver.SetUserToLocalStorage(User);
            Driver.Refresh();
        }

        private User GetAuthenticatedUser()
        {
            var loginDto = new LoginDto
            {
                Email = User.Email,
                Password = User.Password
            };

            var request = RestFactory.CreateRequest(UrlProvider.Authentication);
            request.AddJsonBody(loginDto);

            var response = request.Post<User>();
            return response.Content;
        }

        private void SaveUserDataToContext(User userData)
        {
            User.Token = userData.Token;
            User.Id = userData.Id;
        }
    }
}
