using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace MyForms.ViewModels.Base
{
    public abstract class BaseViewModel
    {
        public Page FormsPage { get; set; }

        public abstract string Identifier { get; }

        public BaseViewModel()
        {
        }

        public async void HandleExceptionAsync(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            await FormsPage.DisplayAlert("Error", "Something wrong happened", "OK");
            // Log analytics
        }
    }
}
