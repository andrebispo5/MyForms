using MyForms.Resources;
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
        public string LoginLabel  => Lang.login;
        public string PlatDialogLabel => Lang.platform_dialog;
        public string CustomRenderLabel => Lang.custom_renderer;
        #endregion

    }
}
