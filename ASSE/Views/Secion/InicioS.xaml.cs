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
using ASSE.Views;
using Rg.Plugins.Popup.Extensions;

namespace ASSE.Views.Secion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioS : ContentPage
    {
        public string usuario, contraseña;
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public string UsuD;
        public InicioS()
        {
            InitializeComponent();
          

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {

            
            try
            {
                await Navigation.PushPopupAsync(new Carga());
                usuario = Lusu.Text;
            contraseña = Lcont.Text;

            
                var prueba1 = await firebaseHelper.GetUsuarioSecion(usuario, contraseña);
                
                if (usuario == prueba1.email && contraseña == prueba1.password)
                {
                    await Navigation.PushAsync(new MainPage(usuario));
                    await Navigation.PopPopupAsync();
                }

            }
            catch (Exception)
            {
                await Navigation.PopPopupAsync();
                await DisplayAlert("Alerta", "Usuario o contraseña incorrecta", "OK");

            }






        }
    }
}