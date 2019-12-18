using Calendar.Models;
using Calendar.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calendar.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        StubUsers users = new StubUsers();

        private string _login;
        public string Login
        {
            get => _login;
            set => _login = value;
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => _password = value;
        }

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
            //var users = obj as StubUsers;
            users.CreateFirstUser();
            List<UserModel> temp = users.GetUsers();
            foreach (var i in temp)
            {
                if (Login.Equals(i.Login) && Password.Equals(i.Password))
                {
                    await _navigationService.NavigateAsync(nameof(Tabs));
                }
            }
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
