using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using winamr.Views;
using System.Threading.Tasks;
using winamr.Bootstrap;
using winamr.Contracts.Services.General;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace winamr
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            InitializeApp();

            InitializeNavigation();

            // MainPage = new MainPage();
            // MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();

            //var shoppingCartViewModel = AppContainer.Resolve<ShoppingCartViewModel>();
            //shoppingCartViewModel.InitializeMessenger();
        }

        private async Task InitializeNavigation()
        {
            var navigationService = AppContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }
    }
}
