using System;
using Ws_Tower_Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ws_Tower_Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FrmSplash();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
