using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ASSE.Views.Secion;
using ASSE.Views.Informes;
using ASSE.Views.Evaluacion;

namespace ASSE
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new InicioS());
            //MainPage = new NavigationPage(new evaluacion2("1", "asse-STK-1"));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
