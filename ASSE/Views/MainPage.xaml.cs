using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


using ASSE.Views.Evaluacion;



using ASSE.Views.Home;
using ASSE.Views.Profile_Settings;
using ASSE.Views.Gestion;
using ASSE.Views.Lista;
using ASSE.Views.Secion;

using Firebase.Database;
using Firebase.Database.Query;
using ASSE.Controls;
using ASSE.Views;
using ASSE.Models;



namespace ASSE
{
 
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public List<MasterPageItem> menuList { get; set; }
        public string usesD;
        public  MainPage(string usu)
        {
            InitializeComponent();


            USER.Text = usu;


            usesD = usu;

            menuList = new List<MasterPageItem>();


            //Fot Android / IOS icons
            var page1 = new MasterPageItem() { id = 1, Title = "ASSE INDEX", Icon = "Home.png" };
            var page2 = new MasterPageItem() { id = 2, Title = "EVALUACION", Icon = "ic_content_paste.png" };
            var page3 = new MasterPageItem() { id = 3, Title = "GESTION DE PRODUCTOS", Icon = "ic_assignment.png" };
            var page4 = new MasterPageItem() { id = 4, Title = "AJUSTES DE PERFIL", Icon = "ProfileSetting.png" };
            var page5 = new MasterPageItem() { id = 5, Title = "LISTAS", Icon = "ic_signal_cellular_alt.png" };
            var page6 = new MasterPageItem() { id = 6, Title = "SALIR", Icon = "ic_input.png" };


            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);
            




            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            await firebaseHelper.UpdateUsuarioStatusLI(usesD);

            var prueba1 = await firebaseHelper.GetUsuarioemail(usesD);

            Uarea.Text = prueba1.Uarea;

        }
        async private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

            
            var myselecteditem = e.Item as MasterPageItem;
             
      

            switch (myselecteditem.id)
            {

                case 1:
                    await Navigation.PushAsync(new HomePage());


                    break;
                case 2:
                    await Navigation.PushAsync(new evaluacion(usesD));
                    
                    break;
                case 3:
                    await Navigation.PushAsync(new Gproducto());

                    break;
                case 4:
                    await Navigation.PushAsync(new Gusuario());

                    break;

                case 5:
                    await Navigation.PushAsync(new ListaPage(usesD));

                    break;
                case 6:
                    await firebaseHelper.UpdateUsuarioStatusLO(usesD);
                    await Navigation.PushAsync(new InicioS());






                    break;
            }
            ((ListView)sender).SelectedItem = null;
            IsPresented = false;


        }
    }
}
