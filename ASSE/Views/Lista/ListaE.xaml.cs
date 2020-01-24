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

namespace ASSE.Views.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaE : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public string Email;
        public ListaE(string email)
        {
            InitializeComponent();
            Email = email;
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allProductos = await firebaseHelper.GetAllProductos();
            lstProductsE.ItemsSource = allProductos.Where(x => x.evaluado==true);
            
           

        }
        private async void MainSearhBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var allProductos = await firebaseHelper.GetAllProductos();
            lstProductsE.ItemsSource = allProductos.Where(x => x.evaluado == true);

            var keyword = MainSearhBar.Text;

            lstProductsE.ItemsSource = allProductos.Where(x => x.Pnombre.ToLower().Contains(keyword.ToLower()));
        }

        private async void LstProductsE_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Producto;
            await Navigation.PushAsync(new Informe(item.Pid, Email));
        }
    }
}