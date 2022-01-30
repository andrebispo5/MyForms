using MyForms.Services;
using MyForms.Services.Interfaces;
using MyForms.ViewModels.Base;
using Xamarin.Forms;

namespace MyForms.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public IAppDataService AppDataService { get; }

        public override string Identifier => "LoginPage";

        public string MyInput { get; set; }

        public LoginViewModel(IAppDataService appDataService, IDialogService dialogService)
            : base(dialogService)
        {
            AppDataService = appDataService;
        }

        public async void ShowInputDialogClicked()
        {
            var result = await DialogService.ShowPrompt();
            System.Console.WriteLine(result);
        }


        #region TextLabels
        public string LoginLabel  => "Login";
        public string PlatDialogLabel => "Platform Dialog Service";
        public string CustomRenderLabel => "Custom Renderer";
        #endregion

    }
}
