using Calendar.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calendar.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            Title = "Main Page";
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(_navigationService));
        }

        private ICommand _navigationCommand;
        public ICommand NavigationCommand => _navigationCommand
              ?? (_navigationCommand = new
                 Command(OnNavigationCommand));

        private async void OnNavigationCommand(object obj)
        {            
          await _navigationService.NavigateAsync(nameof(Tabs));
        }


        private ICommand navigationRecovery;
        public ICommand NavigationRecovery => navigationRecovery
          ?? (navigationRecovery = new
             Command(OnNavigationRecovery));

        private async void OnNavigationRecovery(object obj)
        {
            await _navigationService.NavigateAsync(nameof(ForgottPassword));
        }


        private ICommand navigationRegistration;
        public ICommand NavigationRegistration => navigationRegistration
          ?? (navigationRegistration = new
             Command(OnNavigationRegistration));

        private async void OnNavigationRegistration(object obj)
        {
            await _navigationService.NavigateAsync(nameof(RegistrationPage));
        }
    }
}
