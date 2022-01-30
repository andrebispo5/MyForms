using System.Linq;
using System.Reflection;
using MyForms.Pages.MyLogin;
using MyForms.Services;
using SimpleInjector;
using Xamarin.Forms;

namespace MyForms
{
    public partial class App : Application
    {
        public static Container Container { get; private set; } = CreateContainer();

        public App()
        {
            InitializeComponent();
            InitIOC();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void InitIOC()
        {
            Container.Register<IAppDataService, AppDataService>();
            RegisterViewModelsAuto();
            Container.Verify();
        }

        private static Container CreateContainer()
        {
            var container = new Container();
            container.Options.AllowOverridingRegistrations = true;
            container.Options.EnableAutoVerification = false;

            return container;
        }

        protected void RegisterViewModelsAuto()
        {
            var repositoryAssembly = GetType().GetTypeInfo().Assembly;

            var registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.Namespace.StartsWith("MyForms.ViewModels")
                where !type.IsNested
                where !type.GetTypeInfo().IsAbstract
                select new { Implementation = type };

            foreach (var reg in registrations)
            {
                Container.Register(reg.Implementation, reg.Implementation, Lifestyle.Transient);
            }
        }
    }
}
