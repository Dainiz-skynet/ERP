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

using Rg.Plugins.Popup.Extensions;

namespace ASSE.Views.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaU : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public ListaU()
        {
            InitializeComponent();
            selecB.Items.Add("Uid");
            selecB.Items.Add("email");
            selecB.Items.Add("Ugrupo");
            selecB.Items.Add("Uarea");
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allUsuarios = await firebaseHelper.GetAllUsuarios();
            lstPersons.ItemsSource = allUsuarios;

            //var prueba1 = await firebaseHelper.GetUsuarioN();

            
            //prueba.Text = prueba1.unombre;



        }


        private async void MainSearhBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var allUsuarios = await firebaseHelper.GetAllUsuarios();
                lstPersons.ItemsSource = allUsuarios;

                var keyword = MainSearhBar.Text;

                if (selecB.SelectedItem.ToString() == "Uid")
                {
                    lstPersons.ItemsSource = allUsuarios.Where(x => x.Uid.ToLower().Contains(keyword.ToLower()));
                }

                else if (selecB.SelectedItem.ToString() == "email")
                {
                    lstPersons.ItemsSource = allUsuarios.Where(x => x.email.ToLower().Contains(keyword.ToLower()));
                }

                else if (selecB.SelectedItem.ToString() == "Ugrupo")
                {
                    lstPersons.ItemsSource = allUsuarios.Where(x => x.Ugrupo.ToLower().Contains(keyword.ToLower()));
                }
                
                else if (selecB.SelectedItem.ToString() == "Uarea")
                {
                    lstPersons.ItemsSource = allUsuarios.Where(x => x.Uarea.ToLower().Contains(keyword.ToLower()));
                }
            }
            catch (Exception)
            {
                await this.DisplayAlert("Advertencia", "seleccione un campo de busqueda.", "OK");
            }
        }

        private async void LstPersons_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Usuario;

            await Navigation.PushPopupAsync(new PoplistaU(item.email));
        }
    }
}