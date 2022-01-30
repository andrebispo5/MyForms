using System;
using System.Threading.Tasks;
using MyForms.Pages.Dialogs;

namespace MyForms.Services.Interfaces
{
    public interface IDialogService
    {
        bool IsDialogOpen();

        void ShowLoading();

        Task<string> ShowPrompt();

        void HideDialog();

        Task ShowAlert(string title, string message, string cancel);
    }
}
