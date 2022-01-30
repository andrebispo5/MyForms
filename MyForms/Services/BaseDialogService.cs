using System;
using System.Threading.Tasks;
using MyForms.Pages.Dialogs;
using MyForms.Services.Interfaces;

namespace MyForms.Services
{
    public abstract class BaseDialogService : IDialogService
    {
        public BaseDialogService()
        {
        }

        public bool IsDialogOpen()
        {
            return IsDialogOpenPlat();
        }

        public void HideDialog()
        {
            HideDialogPlat();
        }

        public void ShowLoading()
        {
            LoadingDialogPage dlg = new LoadingDialogPage();
            ShowLoadingPlat(dlg);
        }

        public Task<string> ShowPrompt()
        {
            TaskCompletionSource<string> dialogCompletion = new TaskCompletionSource<string>();
            PromptDialogPage dialog = new PromptDialogPage();

            dialog.Canceled += (object sender, object result) => { this.HideDialogPlat(); dialogCompletion.SetResult((string)result); };
            dialog.Confirmed += (object sender, object result) => { this.HideDialogPlat(); dialogCompletion.SetResult((string)result); };
            this.ShowPromptPlat(dialog);
            return dialogCompletion.Task;
        }


        public abstract bool IsDialogOpenPlat();

        public abstract void ShowLoadingPlat(LoadingDialogPage dialog);

        public abstract void ShowPromptPlat(PromptDialogPage dialog);

        public abstract void HideDialogPlat();

        public async Task ShowAlert(string title, string message, string cancel) => await App.Current.MainPage.DisplayAlert(title, message, cancel);
    }
}
