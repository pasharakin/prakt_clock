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
    public partial class Page2 : ContentPage
    {
        bool timerStart = false;
        int second = 0;
        public List<string> times = new List<string>();
        int counter = 0;
        public Page2()
        {
            InitializeComponent();
            btn_Flag.IsVisible = false;
            btn_Restart.IsVisible = false;
            btn_Stop.IsVisible = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), TimeUpdate);
        }
        private bool TimeUpdate()
        {
            if (timerStart)
            {
                TimeSpan t1 = TimeSpan.FromSeconds(second);
                second++;
                time_StopWatch.Text = t1.ToString();
            }
            return true;
        }

        private void butonStart_Clicked(object sender, EventArgs e)
        {
            btn_Flag.IsVisible = true;
            btn_Restart.IsVisible = false;
            btn_Start.IsVisible = false;
            btn_Stop.IsVisible = true;
            timerStart = true;
        }

        private void butonRestart_Clicked(object sender, EventArgs e)
        {
            btn_Restart.IsVisible = false;
            time_StopWatch.Text = "00:00:00";
            second = 0;
        }

        private void butonStop_Clicked(object sender, EventArgs e)
        {
            btn_Flag.IsVisible = false;
            btn_Restart.IsVisible = true;
            btn_Stop.IsVisible = false;
            btn_Start.IsVisible = true;
            timerStart = false;
        }

        private void butonMark_Clicked(object sender, EventArgs e)
        {
            Label l = new Label();
            l.FontSize = 25;
            counter++;
            string s = counter.ToString() + "    " + time_StopWatch.Text;
            l.Text = s;
            Stack.Children.Add(l);
        }
    }
}