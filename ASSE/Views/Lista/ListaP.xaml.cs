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

namespace ASSE.Views.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaP : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public ListaP()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allProductos = await firebaseHelper.GetAllProductos();
            lstProducts.ItemsSource = allProductos;



        }

        public async void MainSearhBar1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}