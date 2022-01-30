using MyForms.Pages.Landing.Tabs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyForms.Pages.Landing.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingTabbedPage : TabbedPage
    {
        public LandingTabbedPage()
        {
            InitializeComponent();

            NavigationPage firstTab = new NavigationPage(new FirstTabPage());
            NavigationPage secondTab = new NavigationPage(new FirstTabPage());

            firstTab.IconImageSource = "icon";
            firstTab.Title = "First";
            firstTab.IconImageSource = "icon";
            firstTab.Title = "Second";

            Children.Add(firstTab);
            Children.Add(secondTab);
        }
    }
}
