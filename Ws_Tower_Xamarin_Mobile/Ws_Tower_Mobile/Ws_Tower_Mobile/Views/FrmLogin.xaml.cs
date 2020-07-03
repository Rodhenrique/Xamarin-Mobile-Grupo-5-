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
    public partial class FrmLogin : ContentPage
    {
        public FrmLogin()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Frm_Principal());
        }

        private void btnCadastro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FrmCadastro());
        }
    }
}