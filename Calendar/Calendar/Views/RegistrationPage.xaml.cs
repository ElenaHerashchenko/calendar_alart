using Calendar.ViewModels;
using Xamarin.Forms;

namespace Calendar.Views
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = new RegistrationPageViewModel();
        }
    }
}
