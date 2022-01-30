using Android.App;
using MyForms.Extensions;
using MyForms.Pages.Dialogs;
using MyForms.Services;

namespace MyForms.Droid.Services
{
    public class DialogService : BaseDialogService
    {
        private static DialogFragment currentDialog;

        /// <summary>
        /// returns if a dialog is already open
        /// </summary>
        /// <returns></returns>
        public override bool IsDialogOpenPlat()
        {
            return (currentDialog != null && currentDialog.IsVisible);
        }

        /// <summary>
        /// Initialize Dialog Service with activity
        /// </summary>
        /// <param name="activity">activity</param>
        public static void Init(Activity activity)
        {
            Activity = activity;
        }

        public static Activity Activity { get; set; }

        /// <summary>
        /// Displays a loading dialog
        /// </summary>
        /// <param name="dialog">Instance of progress dialog (xamarin.forms)</param>
        public override void ShowLoadingPlat(LoadingDialogPage dialog)
        {
            if (Activity == null)
                return;

            DialogFragment frag = dialog.CreateDialogFragment(Activity);

            frag.SetStyle(DialogFragmentStyle.NoTitle, Resource.Style.AlertDialog_AppCompat);
            frag.Show(Activity.FragmentManager, "dialog");
            currentDialog = frag;
        }

        /// <summary>
        /// Displays a prompt dialog
        /// </summary>
        /// <param name="dialog"></param>
        public override void ShowPromptPlat(PromptDialogPage dialog)
        {
            if (Activity == null)
                return;

            DialogFragment frag = dialog.CreateDialogFragment(Activity);

            frag.SetStyle(DialogFragmentStyle.NoTitle, Resource.Style.AlertDialog_AppCompat);
            frag.Show(Activity.FragmentManager, "dialog");
            currentDialog = frag;
        }

        /// <summary>
        /// Hides loading dialog
        /// </summary>
        public override void HideDialogPlat()
        {
            if (Activity == null)
                return;

            if (currentDialog != null)
            {
                currentDialog.Dismiss();
                currentDialog = null;
            }
        }
    }
}
