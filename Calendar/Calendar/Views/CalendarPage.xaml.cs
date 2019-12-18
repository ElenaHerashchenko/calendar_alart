using System;
using System.Linq;
using Xamarin.Forms;

namespace Calendar.Views
{
    public partial class CalendarPage : ContentPage
    {
        int year;
        int mounth;
        string[] allMonth;
        Label label;



        public CalendarPage()
        {
            InitializeComponent();
            CreateLable();
        }
        private void ChangeMonth()
        {
            int countDays = DateTime.DaysInMonth(year, mounth);
            int startDay = (int)(new DateTime(year, mounth, 1).DayOfWeek);
            var temp = Grib.Children.OfType<Label>().ToList();
            ShowMonth(mounth);
            bool flagFirstString = false;
            int number = 0;
            for (int i = 1; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (number < countDays)
                    {
                        if (j >= startDay || flagFirstString)
                        {
                            flagFirstString = true;
                            temp[j + 7 * i].Text = "";
                            number++;
                            temp[j + 7 * i].Text = number.ToString();
                        }
                        else
                        {
                            temp[j + 7 * i].Text = "";
                        }
                        Grid.SetRow(label, i);
                        Grid.SetColumn(label, j);
                    }
                    else
                    {
                        temp[j + 7 * i].Text = "";
                    }
                }
            }
        }
        private void ShowMonth(int mounth)
        {
            lblMonth.Text = allMonth[mounth - 1];
            Grid.SetRow(lblMonth, 8);
            Grid.SetColumn(lblMonth, 2);
        }
        private void CreateLable()
        {
            year = DateTime.Now.Year;
            mounth = DateTime.Now.Month;
            allMonth = new string[] { "Январь", "Февраль", "Март", "Апрель",
                "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь",
                "Ноябрь", "Декабрь"};
            int countDays = DateTime.DaysInMonth(year, mounth);
            int startDay = (int)(new DateTime(year, mounth, 1).DayOfWeek);
            ShowMonth(mounth);
            //lblMonth.Text = allMonth[mounth-1];
            int number = 0;
            for (int i = 1; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    label = new Label();
                    if (j < startDay)
                    {
                        label.Text = "";
                    }
                    else
                    {
                        number++;
                        label.Text = number.ToString();
                    }
                    Grib.Children.Add(label);
                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, j);
                    if (number > countDays)
                    {
                        number++;
                        label.Text = "";
                    }
                }
            }
        }
        private void PreviosButton_Clicked(object sender, EventArgs e)
        {
            if (mounth == 1)
            {
                year -= 1;
                mounth = 12;
                ChangeMonth();
            }
            else
            {
                mounth -= 1;
                ChangeMonth();
            }
        }
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            if (mounth == 12)
            {
                year += 1;
                mounth = 1;
                ChangeMonth();
            }
            else
            {
                mounth += 1;
                ChangeMonth();
            }
        }
    }
}

