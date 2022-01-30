using System;
using CoreGraphics;
using MyForms.Pages.Dialogs;
using MyForms.Services;
using MyForms.Services.Interfaces;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace MyForms.iOS.Services
{
    public class DialogService : BaseDialogService
    {
        private UIViewController currentDialog;
        private UIWindow popupWindow = null;

        public override void HideDialogPlat()
        {
            if (currentDialog != null)
            {
                UIApplication.SharedApplication.KeyWindow.RootViewController.DismissModalViewController(false);
                currentDialog.Dispose();
                currentDialog = null;
            }
        }

        public override bool IsDialogOpenPlat()
        {
            return (currentDialog != null && currentDialog.IsBeingPresented);
        }

        public override void ShowLoadingPlat(LoadingDialogPage dialog)
        {
            UIViewController dialogController = dialog.CreateViewController();
            ShowDialog(dialogController);
            currentDialog = dialogController;

        }

        public override void ShowPromptPlat(PromptDialogPage dialog)
        {
            UIViewController dialogController = dialog.CreateViewController();
            ShowDialog(dialogController);
            currentDialog = dialogController;
        }

        private void ShowDialog(UIViewController dialogController)
        {
            var bounds = UIScreen.MainScreen.Bounds;
            dialogController.View.Frame = bounds;
            UIApplication.SharedApplication.KeyWindow.RootViewController.ModalPresentationStyle = UIModalPresentationStyle.CurrentContext;
            UIApplication.SharedApplication.KeyWindow.RootViewController.AddChildViewController(dialogController);
            UIApplication.SharedApplication.KeyWindow.RootViewController.View.Opaque = false;
            UIApplication.SharedApplication.KeyWindow.RootViewController.View.Layer.AllowsGroupOpacity = true;
            UIApplication.SharedApplication.KeyWindow.RootViewController.View.Layer.BackgroundColor = new CGColor(Color.White.ToCGColor(), 0.0f);
            UIApplication.SharedApplication.KeyWindow.RootViewController.View.BackgroundColor = UIColor.Clear;
            UIApplication.SharedApplication.KeyWindow.RootViewController.View.AddSubview(dialogController.View);
            dialogController.ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext;
            dialogController.View.Opaque = false;
            dialogController.View.BackgroundColor = UIColor.Clear.ColorWithAlpha(0.0f);
        }
    }
}
