using Calendar.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calendar.ViewModels
{
    public class TabsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public TabsViewModel(INavigationService navigationService)
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
            await _navigationService.NavigateAsync(nameof(Alarm));
        }
    }
}
