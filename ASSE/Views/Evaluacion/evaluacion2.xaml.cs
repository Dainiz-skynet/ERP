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
    public partial class evaluacion2 : ContentPage
    {

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public string codigo,Uemail;
        public evaluacion2(string email,string cod)
        {
            InitializeComponent();
            codigo = cod;
            Uemail = email;

        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allProductos = await firebaseHelper.GetProductoAleatorio();
            allProductos.Count();

            double n = ((Math.Pow(1.96, 2) * 0.5 * (1 - 0.5)) / (Math.Pow(.10, 2))) /
                      (1 + (((Math.Pow(1.96, 2) * 0.5 * (1 - 0.5)) / ((Math.Pow(.10, 2)) * allProductos.Count()))));                                    ;
            lstProducts.ItemsSource = allProductos.Where(x => x.Pstockid == codigo && x.evaluado==false).Take(Convert.ToInt32(n));

            Muestra.Text = Convert.ToString(Convert.ToInt32(n));

        }


        private async void LstProducts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Producto;
            await Navigation.PushAsync(new Especificaciones(item.Pid,Uemail,codigo));
        }
    }
}