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
    public partial class Frm_Principal : MasterDetailPage
    {
        public Frm_Principal()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.Master = new Master();
            this.Detail = new NavigationPage(new Details());
        }
    }
}