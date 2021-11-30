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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            time_Time.Text = DateTime.Now.ToString("    HH:mm:ss");
            date_Date.Text = DateTime.Now.ToString("dd.MM.yyyy");
            Device.StartTimer(TimeSpan.FromSeconds(1), TimeUpdate);
        }
        private bool TimeUpdate()
        {
            time_Time.Text = DateTime.Now.ToString("    HH:mm:ss");
            date_Date.Text = DateTime.Now.ToString("dd.MM.yyyy");
            return true;
        }
    }
}