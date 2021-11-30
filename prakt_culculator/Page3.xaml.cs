using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prakt_culculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        TimeSpan timeSpan;
        bool isRun;
        
        public Page3()
        {
            InitializeComponent();
            btn_Restart.IsVisible = false;
            btn_Stop.IsVisible = false;
            timer.IsVisible = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerTick);
        }

        private void butonStart_Clicked(object sender, EventArgs e)
        {
            if (timePicker.Time.CompareTo(new TimeSpan(0, 0, 0)) != 0)
            {
                timeSpan = timePicker.Time;
                btn_Start.IsVisible = false;
                btn_Restart.IsVisible = false;
                btn_Stop.IsVisible = true;
                timer.IsVisible = true;
                timePicker.IsVisible = false;
                isRun = true;
            }
            else
            {
                DisplayAlert("Ошибка", "Установите время", "Ок");
            }
        }

        private void buton_Restart_Clicked(object sender, EventArgs e)
        {
            btn_Start.IsVisible = true;
            btn_Restart.IsVisible = false;
            btn_Stop.IsVisible = false;
            timer.IsVisible = false;
            timePicker.IsVisible = true;
            isRun = false;
            timePicker.Time = new TimeSpan(0, 0, 0);
        }

        private void butonStop_Clicked(object sender, EventArgs e)
        {
            btn_Start.IsVisible = true;
            btn_Restart.IsVisible = true;
            btn_Stop.IsVisible = false;
            timer.IsVisible = true;
            timePicker.IsVisible = false;
            isRun = false;
            timePicker.Time = TimeSpan.Parse(timer.Text);
        }

        bool TimerTick()
        {
            if (isRun)
            {
                timeSpan = timeSpan.Add(new TimeSpan(0, 0, -1));
                timer.Text = timeSpan.ToString();
                if (timeSpan.CompareTo(new TimeSpan(0, 0, 0)) == 0)
                {
                    DisplayAlert("Таймер", "Время вышло", "Ок");
                    isRun = false;
                    timer.IsVisible = false;
                    timePicker.IsVisible = true;
                    btn_Start.IsVisible = true;
                    btn_Stop.IsVisible = false;
                    btn_Restart.IsVisible = false;
                }
            }

            return true;
        }
    }
}