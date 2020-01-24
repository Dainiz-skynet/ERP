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
using System.Text.RegularExpressions;

namespace ASSE.Views.Gestion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gproducto : ContentPage
    {
        
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        
        public Gproducto()
        {
            InitializeComponent();
            PickStokid.Items.Add("asse-STK-1");
            txtPnombre.Items.Add("OMEN by HP");
            txtPnombre.Items.Add("v200 by HP");
            txtProvedor.Items.Add("HP");
            txtCategoria.Items.Add("Pantalla");
            txtCategoria.Items.Add("Monitor");
            txtPrecio.Items.Add(Convert.ToString(5099));
            

        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allUsuarios = await firebaseHelper.GetAllProductos();
            lstProduct.ItemsSource = allUsuarios;
           
        }



        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrWhiteSpace(txtPnombre.SelectedItem.ToString()))
                {
                    await this.DisplayAlert("Advertencia", "El campo del nombre es obligatorio.", "OK");

                }
                else if (String.IsNullOrWhiteSpace(txtCategoria.SelectedItem.ToString()))
                {
                    await this.DisplayAlert("Advertencia", "El campo del categoria es obligatorio.", "OK");

                }
                else if (String.IsNullOrWhiteSpace(txtProvedor.SelectedItem.ToString()))
                {
                    await this.DisplayAlert("Advertencia", "El campo del provedor es obligatorio.", "OK");

                }
                else if (String.IsNullOrWhiteSpace(txtPrecio.SelectedItem.ToString()))
                {
                    await this.DisplayAlert("Advertencia", "El campo del precio es obligatorio.", "OK");

                }
                else
                {
                    var allUsuarios = await firebaseHelper.GetAllProductos();
                    string Pids = "asse-PRO-" + allUsuarios.Count().ToString();

                    await firebaseHelper.AddProducto(Pids, txtCategoria.SelectedItem.ToString(), txtPnombre.SelectedItem.ToString(), Convert.ToDouble(txtPrecio.SelectedItem.ToString()), txtProvedor.SelectedItem.ToString(), PickStokid.SelectedItem.ToString());
                    await firebaseHelper.UpdateStock(PickStokid.SelectedItem.ToString());
                    txtPid.Text = string.Empty;



                    await DisplayAlert("Success", "Producto agregado", "OK");
                    var allUsuarios1 = await firebaseHelper.GetAllProductos();
                    lstProduct.ItemsSource = allUsuarios1;
                }
            }
            catch (Exception)
            {
                await this.DisplayAlert("Advertencia", "no deve haver campos vacios.", "OK");
            }

        }


        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrWhiteSpace(txtPnombre.SelectedItem.ToString()))
                {
                    await this.DisplayAlert("Advertencia", "El campo del nombre es obligatorio.", "OK");

                }
                else if (String.IsNullOrWhiteSpace(txtCategoria.SelectedItem.ToString()))
                {
                    await this.DisplayAlert("Advertencia", "El campo del categoria es obligatorio.", "OK");

                }
                else if (String.IsNullOrWhiteSpace(txtProvedor.SelectedItem.ToString()))
                {
                    await this.DisplayAlert("Advertencia", "El campo del provedor es obligatorio.", "OK");

                }
                else if (String.IsNullOrWhiteSpace(txtPrecio.SelectedItem.ToString()))
                {
                    await this.DisplayAlert("Advertencia", "El campo del precio es obligatorio.", "OK");

                }
                else
                {
                    await firebaseHelper.UpdateProducto(txtPid.Text, txtCategoria.SelectedItem.ToString(), txtPnombre.SelectedItem.ToString(), Convert.ToDouble(txtPrecio.SelectedItem.ToString()), txtProvedor.SelectedItem.ToString(), PickStokid.SelectedItem.ToString());

            

            await DisplayAlert("Success", "Producto actualizado", "OK");
            var allPersons = await firebaseHelper.GetAllProductos();
            lstProduct.ItemsSource = allPersons;
                }
            }
            catch (Exception)
            {
                await this.DisplayAlert("Advertencia", "no deve haver campos vacios.", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                await firebaseHelper.DeleteProducto(txtPid.Text);
                await DisplayAlert("Success", "Producto borrado", "OK");
                var allPersons = await firebaseHelper.GetAllProductos();
                lstProduct.ItemsSource = allPersons;
            }
            catch (Exception)
            {
                await this.DisplayAlert("Advertencia", "no deve haver campos vacios.", "OK");
            }
        }

        private void LstProduct_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Producto;
            txtPid.Text = item.Pid;
            txtPnombre.SelectedItem = item.Pnombre;
            txtCategoria.SelectedItem = item.Categoria;
            txtProvedor.SelectedItem = item.Provedor;
            PickStokid.SelectedItem = item.Pstockid;
            txtPrecio.SelectedItem = item.Precio.ToString();
        }
    }
}