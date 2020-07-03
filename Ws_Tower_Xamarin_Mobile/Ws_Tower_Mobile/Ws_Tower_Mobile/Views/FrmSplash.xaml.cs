using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ws_Tower_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmSplash : ContentPage
    {
        public FrmSplash()
        {
            InitializeComponent();
            Animation();
        }

        public async Task Animation()
        {
            ImagemLogo.Opacity = 0;
            await ImagemLogo.FadeTo(1, 3000);
            Application.Current.MainPage = new FrmLogin();
        }
    }
}