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
using System.Windows.Input;
using Xamarin.Forms;

namespace Calendar.ViewModels
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        UserModel _user;
        StubUsers _stubUsers = new StubUsers();

        public RegistrationPageViewModel() { }

        private string _error;
        public string Error
        {
            get => _error;
            set => SetProperty(ref _error, value);
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        private string _secondName;
        public string SecondName
        {
            get => _secondName;
            set => _secondName = value;
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public string _email;
        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string _age;
        public string Age
        {
            get => _age;
            set => _age = value;
        }

        public string _login;
        public string Login
        {
            get => _login;
            set => _login = value;
        }

        public string _password;
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        private readonly INavigationService _navigationService;
        public RegistrationPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Registration";
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(_navigationService));
        }

        private System.Windows.Input.ICommand _navigationCommand;
        public ICommand NavigationCommand => _navigationCommand
              ?? (_navigationCommand = new
                 Command(OnNavigationCommand));

        private async void OnNavigationCommand(object obj)
        {
            int numAge;
            bool isAge = Int32.TryParse(Age, out numAge);
            if (isAge)
            {
                _user = new UserModel(FirstName, SecondName, Phone, Email, numAge, Login, Password);

                bool result = Validate(_user);
                if (result)
                {
                    _stubUsers.AddUser(_user);
                    await _navigationService.NavigateAsync(nameof(MainPage));
                }
            }
            else
                Error = "Unacceptable age";
        }

        public bool Validate(UserModel user)
        {
            var str = "";
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    str += error.ErrorMessage + "\n";
                }
                Error = str;
                return false;
            }
            return true;
        }
    }
}
