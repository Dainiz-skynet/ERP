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
using ASSE.Views.Evaluacion;
using ASSE.Views.Lista;
using System.Text.RegularExpressions;
using Rg.Plugins.Popup.Extensions;


namespace ASSE.Views.Profile_Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gusuario : ContentPage
    {

        
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public Gusuario()
        {
            InitializeComponent();
            PickUtipo.Items.Add("ADMINISTRADOR");
            PickUtipo.Items.Add("USUARIO");

            PickUarea.Items.Add("CTO (Chief Technology Officer)");
            PickUarea.Items.Add("QA(QUALITY ASSESSMENT)");
            PickUarea.Items.Add("CIO (Chief Information Officer)");
            PickUarea.Items.Add("CMO (Chief Marketing Officer)");
            PickUarea.Items.Add("ALMACENISTA");

        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allUsuarios = await firebaseHelper.GetAllUsuarios();
            
           
            lstPersons.ItemsSource = allUsuarios;


        }


        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ususE = await firebaseHelper.GetAllUsuarios();
                bool isEmail = Regex.IsMatch(txtemail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    await this.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");

                }
                else if (String.IsNullOrWhiteSpace(txtemail.Text))
                {
                    await this.DisplayAlert("Advertencia", "El campo del email es obligatorio.", "OK");

                }
                else if (String.IsNullOrWhiteSpace(txtpassword.Text))
                {
                    await this.DisplayAlert("Advertencia", "El campo del password es obligatorio.", "OK");

                }
                else if (ususE.Where(x => x.email == txtemail.Text).Count()==1)
                {
                    await this.DisplayAlert("Advertencia", "YA EXISTE ESE USUARIO HEHE", "OK");

                }
                else
                {
                    DateTime FECHA = DateTime.Now;
                    var all = await firebaseHelper.GetAllUsuarios();
                    string Uids = "asse-" + all.Count().ToString();

                    await firebaseHelper.AddUsuario(Uids, txtemail.Text, txtpassword.Text, PickUtipo.SelectedItem.ToString(), FECHA.ToString("MM-dd-yyy"), PickUarea.SelectedItem.ToString());
                    txtUid.Text = string.Empty;
                    txtemail.Text = string.Empty;
                    txtpassword.Text = string.Empty;

                    await DisplayAlert("Success", "usuario agregado", "OK");
                    var allUsuarios = await firebaseHelper.GetAllUsuarios();
                    lstPersons.ItemsSource = allUsuarios;
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
                bool isEmail = Regex.IsMatch(txtemail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    await this.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");

                }
                else if (String.IsNullOrWhiteSpace(txtemail.Text))
                {
                    await this.DisplayAlert("Advertencia", "El campo del email es obligatorio.", "OK");

                }
                else if (String.IsNullOrWhiteSpace(txtpassword.Text))
                {
                    await this.DisplayAlert("Advertencia", "El campo del password es obligatorio.", "OK");

                }
                else
                {
                    await firebaseHelper.UpdateUsuario(txtUid.Text, txtemail.Text, txtpassword.Text, PickUtipo.SelectedItem.ToString(),PickUarea.SelectedItem.ToString());
            txtUid.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtpassword.Text = string.Empty;
           

            await DisplayAlert("Success", "Persona actualizada", "OK");
            var allPersons = await firebaseHelper.GetAllUsuarios();
            lstPersons.ItemsSource = allPersons;
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
                await firebaseHelper.DeleteUsuario(txtUid.Text);
                await DisplayAlert("Success", "Persona borrada", "OK");
                var allPersons = await firebaseHelper.GetAllUsuarios();
                lstPersons.ItemsSource = allPersons;
            }
            catch (Exception)
            {
                await this.DisplayAlert("Advertencia", "no deve haver campos vacios.", "OK");
            }
        }

        private void LstPersons_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemP = e.SelectedItem as Usuario;
            txtUid.Text = itemP.Uid;
            txtemail.Text = itemP.email;
            txtpassword.Text = itemP.password;
            PickUarea.SelectedItem = itemP.Uarea;
            PickUtipo.SelectedItem = itemP.Ugrupo;

        }
    }


}
