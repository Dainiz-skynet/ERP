using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Firebase.Database;
using Firebase.Database.Query;
using ASSE.Controls;
using ASSE.Models;
using ASSE.Views.Informes;


using Microcharts;
using SkiaSharp;
using Entry = Microcharts.Entry;

using ASSE.Views.Secion;
using Rg.Plugins.Popup.Extensions;

namespace ASSE.Views.Informes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Informe : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public string PPid, EEmail;
        public Informe(string Pid,string email)
        {
            InitializeComponent();
            PPid = Pid;
            EEmail = email;
        }
        
        protected async override void OnAppearing()
        {

            base.OnAppearing();

            await Navigation.PushPopupAsync(new CargaG());

            var allProductos= await firebaseHelper.GetProductoid(PPid);
            Pid.Text = allProductos.Pid;
            Pnombre.Text = allProductos.Pnombre;
            Provedor.Text = allProductos.Provedor;
            Categoria.Text = allProductos.Categoria;
            Precio.Text = allProductos.Precio.ToString();
            Pstockid.Text = allProductos.Pstockid;
            evaluado.IsChecked = allProductos.evaluado;
            defectuoso.IsChecked = allProductos.defectuoso;

            var allEsp = await firebaseHelper.GetAllEspecificacionesP();
            lstEspecificaciones.ItemsSource = allEsp.Where(x => x.Pid == PPid);

            var uidE = await firebaseHelper.GetEspsid(PPid);

           
           
           
            var allUsuarios = await firebaseHelper.GetUsuarioemail(uidE.email);

            Usuario.Text = allUsuarios.email;
            Uid.Text = allUsuarios.Uid;
            Ugrupo.Text = allUsuarios.Ugrupo;
            Uarea.Text = allUsuarios.Uarea;


            int TprodE = allEsp.Where(x => x.Eselec == true && x.Pid == PPid).Count();
            int TprodNE = allEsp.Where(x => x.Eselec == false && x.Pid == PPid).Count();

            List<Entry> entries2 = new List<Entry>
 {

     new Entry(TprodE)
     {
         Label = "Evaluados",
         ValueLabel = TprodE.ToString(),
         Color = SKColor.Parse("#77d065")
     },
          new Entry(TprodNE)
     {
         Label = "No evaluados",
         ValueLabel = TprodNE.ToString(),
         Color = SKColor.Parse("#77d065")
     },


};

            var chart = new RadarChart() { Entries = entries2 };

           especificaciones.Chart = chart;

            await Navigation.PopPopupAsync();
        }
        

    }
}