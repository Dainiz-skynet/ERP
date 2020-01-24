using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using ZXing;
using ZXing.Net.Mobile.Forms;
using ASSE.Views.Evaluacion;

namespace ASSE.Views.Evaluacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class evaluacion : ContentPage
    {

        public string Uemail;
        public evaluacion(string email)
        {
            InitializeComponent();
            Uemail = email;
        }

        private async void Button_click(object sender, EventArgs e)
        {
            var scannerPage = new ZXingScannerPage();
            await Navigation.PushAsync(scannerPage);

            scannerPage.OnScanResult += (result) =>
            {

                scannerPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async() =>
                {
                  
                  await Navigation.PushAsync(new evaluacion2(Uemail,result.Text));
                });
            };
        }


    }
}