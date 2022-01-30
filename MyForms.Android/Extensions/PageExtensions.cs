using System;
using System.Reflection;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MyForms.Extensions
{
    public static class PageExtensions
    {
        public static DialogFragment CreateDialogFragment(this ContentPage view, Context context)
        {
            if (!Forms.IsInitialized)
                throw new InvalidOperationException("call Forms.Init() before this");

            // Get Platform constructor via reflection and call it to create new platform object
            Platform platform = (Platform)typeof(Platform).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Context), typeof(bool) }, null)
                ?.Invoke(new object[] { context, true });

            // Set the page to the platform
            if (platform != null)
            {
                platform.GetType().GetMethod("SetPage", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(platform, new object[] { view });

                // Finally get the view group
                ViewGroup vg = (Android.Views.ViewGroup)platform.GetType().GetMethod("GetViewGroup", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(platform, null);

                return new EmbeddedDialogFragment(vg, platform);
            }

            return null;
        }

        public class DefaultApplication : Xamarin.Forms.Application
        {
        }

        class EmbeddedDialogFragment : DialogFragment
        {
            readonly ViewGroup _content;
            readonly Platform _platform;
            bool _disposed;

            public EmbeddedDialogFragment()
            {
            }

            public EmbeddedDialogFragment(ViewGroup content, Platform platform)
            {
                _content = content;
                _platform = platform;
            }

            public override global::Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                this.Dialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
                return _content;
            }

            public override void OnDestroy()
            {
                this.Dialog?.Window.SetSoftInputMode(SoftInput.AdjustPan);
                base.OnDestroy();
            }

            protected override void Dispose(bool disposing)
            {
                if (_disposed)
                {
                    return;
                }

                _disposed = true;

                if (disposing)
                {
                    (_platform as IDisposable)?.Dispose();
                }

                base.Dispose(disposing);
            }
        }
    }

}
