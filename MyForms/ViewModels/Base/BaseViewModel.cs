using System;
using System.Diagnostics;
using MyForms.Services.Interfaces;

namespace MyForms.ViewModels.Base
{
    public abstract class BaseViewModel 
    {
        public abstract string Identifier { get; }
        public IDialogService DialogService { get; }

        public BaseViewModel(IDialogService dialogService)
        {
            DialogService = dialogService;
        }

        public async void HandleExceptionAsync(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            await DialogService.ShowAlert("Error", "Something wrong happened", "OK");
            // Log analytics
        }
    }
}
