using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using ASSE.Controls;
using ASSE.Models;
using Rg.Plugins.Popup.Extensions;

namespace ASSE.Views.Evaluacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Especificaciones : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public string Pids,Uemail,EEid;
        public Especificaciones(string Pid, string email, string Eid)
        {
            InitializeComponent();
            Pids = Pid;
            Uemail = email;
            EEid = Eid;
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allEspecificaciones = await firebaseHelper.GetAllEspecificaciones();

            lstEspecificaciones.ItemsSource = allEspecificaciones;

            

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            var confirm = await firebaseHelper.GetEspsidC(Pids);

            if (confirm.Count() < 20)
            {
                await DisplayAlert("Alerta "  , confirm.Count()+" de "+ "20 No se a evaluado.", "OK");
            }
            else if (confirm.Where(x => x.Eselec==false).Count()>=1)
            {

                await firebaseHelper.UpdateProductostatusD(Pids);
                await Navigation.PushAsync(new evaluacion2(Uemail, EEid));
            }

            else if (confirm.Where(x => x.Eselec == false).Count() == 0)
            {
                await firebaseHelper.UpdateProductostatusA(Pids);
                await Navigation.PushAsync(new evaluacion2(Uemail, EEid));
            }



        }

        public string Eids, Enombres, Edescripcions;
        private async void LstEspecificaciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Especificacion;
            await Navigation.PushPopupAsync(new SoN(Pids, Uemail, item.Eid, item.Enombre, item.EDescripcion));
        }
    }
}