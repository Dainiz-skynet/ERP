using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using ASSE.Controls;
using ASSE.Models;
namespace ASSE.Views.Evaluacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SoN : PopupPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public string Pids1,  Uemail1,  Eid1,  Enombre1, EDescripcion1;



        public SoN(string Pids, string Uemail, string Eid, string Enombre, string EDescripcion)
        {
            InitializeComponent();

            Pids1 = Pids;
            Uemail1 = Uemail;
            Eid1 = Eid;
            Enombre1 = Enombre;
            EDescripcion1 = EDescripcion;



        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            

            await firebaseHelper.AddEspecificacion(Pids1, Uemail1, Eid1, Enombre1, EDescripcion1,true);

           await Navigation.PopPopupAsync();


        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await firebaseHelper.AddEspecificacion(Pids1, Uemail1, Eid1, Enombre1, EDescripcion1, false);

            await Navigation.PopPopupAsync();
        }
    }
}