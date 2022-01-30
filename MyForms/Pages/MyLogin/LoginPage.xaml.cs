﻿using MyForms.Pages.Landing.Tabs;
using MyForms.ViewModels;
using Xamarin.Forms;

namespace MyForms.Pages.MyLogin
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _vm = App.Container.GetInstance<LoginViewModel>();

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = _vm;
        }

        void LoginClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new LandingTabbedPage()));
        }

        async void PlatformDialogClicked(System.Object sender, System.EventArgs e) => _vm.ShowInputDialogClicked();

        void CustomRendererClicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
