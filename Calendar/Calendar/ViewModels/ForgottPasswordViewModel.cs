using Calendar.Models;
using Calendar.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calendar.ViewModels
{
    public class ForgottPasswordViewModel : ViewModelBase
    {
        StubUsers users = new StubUsers();

        private string _email;      
        public string Email
        {
            get =>  _email;
            set => _email = value;
        }

        private string _noEmael;
        public string NoEmail
        {
            get => _noEmael;
            set => SetProperty(ref _noEmael, value);
        }

        readonly INavigationService _navigationService;
        public ForgottPasswordViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            Title = "Recovery password";
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(_navigationService));
        }

        ICommand _navigationCommand;
        public ICommand navigationCommand => _navigationCommand
              ?? (_navigationCommand = new
                 Command(OnNavigationCommandBack));
        private async void OnNavigationCommandBack(object obj)
        {
            await _navigationService.NavigateAsync(nameof(MainPage));
        }


        ICommand _navigateCommand;
          public ICommand navigateCommand => _navigateCommand
              ?? (_navigateCommand = new
                 Command(OnNavigationCommand));
        private async void OnNavigationCommand(object obj)
        {
           // var users = obj as StubUsers;
            users.CreateFirstUser();
            bool isEmail = users.CheckEmail(Email);
            if (isEmail)
            {
                await _navigationService.NavigateAsync(nameof(RecoverPage));
            }
            NoEmail = "No Email";
        }
    }
}
