using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyForms.Pages.Dialogs
{
    public partial class PromptDialogPage : ContentPage
    {
        public event EventHandler<object> Confirmed;
        public event EventHandler<object> Canceled;

        public PromptDialogPage()
        {
            InitializeComponent();
        }
        private void OnCancelClick(object sender, EventArgs e)
        {
            Canceled?.Invoke(this, string.Empty);
        }

        private void OnOkayClick(object sender, EventArgs e)
        {
            Confirmed?.Invoke(this, DialogResultText.Text);
        }
    }
}
