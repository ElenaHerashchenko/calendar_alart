using Xamarin.Forms;

namespace Calendar.Views
{
    public partial class Alarm : ContentPage
    {
        public Alarm()
        {
            InitializeComponent();
        }
        private void switcher_Toggled(object sender, ToggledEventArgs e)
        {

            DisplayAlert("Alert", "You set the alarm", "OK");

        }
    }
}
