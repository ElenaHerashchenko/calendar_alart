using Calendar.Models;
using Calendar.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calendar.ViewModels
{
    public class RecoverPageViewModel : ViewModelBase
    {
        StubUsers users = new StubUsers();

        public string _enterPassword;      
        public string EnterPassword
        {
            get => _enterPassword;
            set => SetProperty(ref _enterPassword, value);
        }
        private string _repeatPassword;
        public string RepeatPassword
        {
            get => _repeatPassword;
            set => _repeatPassword = value;
        }

        public string _noValidate;

        public string NoValidate
        {
            get => _noValidate;
            set => SetProperty(ref _noValidate, value);
        }

        readonly INavigationService _navigationService;
        public RecoverPageViewModel(INavigationService navigationService)
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
            //var users = obj as StubUsers;
            users.CreateFirstUser();
            if (_enterPassword.Equals(_repeatPassword))
            {
                if (Validate(_enterPassword))
                {
                    users.RepleacePassword(_enterPassword);
                    await _navigationService.NavigateAsync(nameof(MainPage));
                }
            }
            NoValidate = "No Validate";
        }

        public bool Validate(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
            if (Regex.IsMatch(password, pattern, RegexOptions.IgnoreCase))
            {              
                return true;
            }
            return false;
        }
    }
}
