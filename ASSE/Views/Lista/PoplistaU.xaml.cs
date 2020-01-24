using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;


using Firebase.Database;
using Firebase.Database.Query;
using ASSE.Controls;
using ASSE.Models;

namespace ASSE.Views.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PoplistaU : PopupPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public string Eemail;
        public PoplistaU(string email)
        {
            InitializeComponent();
            Eemail = email;
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allUsuarios = await firebaseHelper.GetUsuarioemail(Eemail);


            Uid.Text = allUsuarios.Uid;
            Usuario.Text = allUsuarios.Uarea;
            Ugrupo.Text = allUsuarios.Ugrupo;
            Uarea.Text = allUsuarios.Uarea;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}