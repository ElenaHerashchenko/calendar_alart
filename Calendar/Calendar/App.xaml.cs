using Prism;
using Prism.Ioc;
using Calendar.ViewModels;
using Calendar.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Calendar.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Calendar
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<RegistrationPage, RegistrationPageViewModel>();
            containerRegistry.RegisterForNavigation<Tabs, TabsViewModel>();
            containerRegistry.RegisterForNavigation<Alarm, AlarmViewModel>();
            containerRegistry.RegisterForNavigation<CalendarPage, CalendarPageViewModel>();


            containerRegistry.Register<IUserModel, UserModel>();


            containerRegistry.RegisterForNavigation<Account, AccountViewModel>();
            containerRegistry.RegisterForNavigation<ForgottPassword, ForgottPasswordViewModel>();
            containerRegistry.RegisterForNavigation<RecoverPage, RecoverPageViewModel>();
        }
    }
}
