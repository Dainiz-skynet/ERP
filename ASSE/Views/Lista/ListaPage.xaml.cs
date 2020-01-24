using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using ASSE.Views.Home;
using ASSE.Views.Profile_Settings;
using ASSE.Views.Gestion;
using ASSE.Views.Lista;
using ASSE.Models;
using ASSE.Views.Evaluacion;


namespace ASSE.Views.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPage : ContentPage
    {
        public string Email;
        public ListaPage(string email)
        {
            InitializeComponent();


            Email = email;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaP());

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaU());

        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaE(Email));
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaU());
        }
    }
}