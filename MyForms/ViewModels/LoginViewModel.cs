using MyForms.Services;
using MyForms.ViewModels.Base;
using Xamarin.Forms;

namespace MyForms.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public IAppDataService AppDataService { get; }

        public override string Identifier => "LoginPage";

        public LoginViewModel(IAppDataService appDataService)
        {
            AppDataService = appDataService;
        }
    }
}
