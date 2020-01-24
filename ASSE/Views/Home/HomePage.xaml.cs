using ASSE.Models;
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
using ASSE.Views.Home;


using Microcharts;
using SkiaSharp;
using Entry = Microcharts.Entry;





namespace ASSE.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();


        public HomePage()
        {
            InitializeComponent();

            
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();


           var allUsuarios = await firebaseHelper.GetAllUsuarios();
            int totalu = allUsuarios.Count();

           var totaluD = allUsuarios.Where(x => x.Status == false);
            
           var totaluC = allUsuarios.Where(a => a.Status == true);

            
            int Des = totaluD.Count();
            int Con = totaluC.Count();


            List<Entry> entries = new List<Entry>
 {
     new Entry(totalu)
     {
         Label = "usuarios",
         ValueLabel = totalu.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
     new Entry(Con)
     {
         Label = "online",
         ValueLabel = Con.ToString(),
         Color = SKColor.Parse("#77d065")
     },
     new Entry(Des)
     {
         Label = "offline",
         ValueLabel = Des.ToString(),
         Color = SKColor.Parse("#b455b6"),

     },
};
            var chart = new BarChart() { Entries = entries };

            charView.Chart = chart;

            var allProd = await firebaseHelper.GetAllProductos();
            var StockV = await firebaseHelper.GetStock();

            
            int Tprod = allProd.Count();
            

            
            List<Entry> entries1 = new List<Entry>
 {
     new Entry(StockV.StockMax)
     {
         Label = "Max",
         ValueLabel = StockV.StockMax.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
          new Entry(1)
     {
         Label = "Min",
         ValueLabel = 1.ToString(),
         Color = SKColor.Parse("#77d065")
     },
     new Entry(Tprod)
     {
         Label = "pruductos",
         ValueLabel = Tprod.ToString(),
         Color = SKColor.Parse("#77d065")
     },


};

            var chart1 = new BarChart() { Entries = entries1 };

            charView1.Chart = chart1;




            var allProdE = await firebaseHelper.GetAllProductos();



            int TprodE = allProdE.Where(x => x.evaluado == true).Count();
            int TprodNE = allProdE.Where(x => x.evaluado == false).Count();

            List<Entry> entries2 = new List<Entry>
 {

     new Entry(TprodE)
     {
         Label = "Evaluados",
         ValueLabel = TprodE.ToString(),
         Color = SKColor.Parse("#77d065")
     },
          new Entry(TprodNE)
     {
         Label = "No evaluados",
         ValueLabel = TprodNE.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },


};

            var chart2 = new DonutChart() { Entries = entries2 };

            charView2.Chart = chart2;


            var allProdEP = await firebaseHelper.GetAllEspecificacionesP();



            int TprodE1 = allProdEP.Where(x => x.Eid == "asse-ESP-1" && x.Eselec==true).Count();
            int TprodE2 = allProdEP.Where(x => x.Eid == "asse-ESP-2" && x.Eselec == true).Count();
            int TprodE3 = allProdEP.Where(x => x.Eid == "asse-ESP-3" && x.Eselec == true).Count();
            int TprodE4 = allProdEP.Where(x => x.Eid == "asse-ESP-4" && x.Eselec == true).Count();
            int TprodE5 = allProdEP.Where(x => x.Eid == "asse-ESP-5" && x.Eselec == true).Count();
            int TprodE6 = allProdEP.Where(x => x.Eid == "asse-ESP-6" && x.Eselec == true).Count();
            int TprodE7 = allProdEP.Where(x => x.Eid == "asse-ESP-7" && x.Eselec == true).Count();
            int TprodE8 = allProdEP.Where(x => x.Eid == "asse-ESP-8" && x.Eselec == true).Count();
            int TprodE9 = allProdEP.Where(x => x.Eid == "asse-ESP-9" && x.Eselec == true).Count();
            int TprodE10 = allProdEP.Where(x => x.Eid == "asse-ESP-10" && x.Eselec == true).Count();
            int TprodE11 = allProdEP.Where(x => x.Eid == "asse-ESP-11" && x.Eselec == true).Count();
            int TprodE12 = allProdEP.Where(x => x.Eid == "asse-ESP-12" && x.Eselec == true).Count();
            int TprodE13 = allProdEP.Where(x => x.Eid == "asse-ESP-13" && x.Eselec == true).Count();
            int TprodE14 = allProdEP.Where(x => x.Eid == "asse-ESP-14" && x.Eselec == true).Count();
            int TprodE15 = allProdEP.Where(x => x.Eid == "asse-ESP-15" && x.Eselec == true).Count();
            int TprodE16 = allProdEP.Where(x => x.Eid == "asse-ESP-16" && x.Eselec == true).Count();
            int TprodE17 = allProdEP.Where(x => x.Eid == "asse-ESP-17" && x.Eselec == true).Count();
            int TprodE18 = allProdEP.Where(x => x.Eid == "asse-ESP-18" && x.Eselec == true).Count();
            int TprodE19 = allProdEP.Where(x => x.Eid == "asse-ESP-19" && x.Eselec == true).Count();
            int TprodE20 = allProdEP.Where(x => x.Eid == "asse-ESP-20" && x.Eselec == true).Count();

            List<Entry> entries3 = new List<Entry>
 {

     new Entry(TprodE1)
     {
         Label = "ESP-1",
         ValueLabel = TprodE1.ToString(),
         Color = SKColor.Parse("#77d065")
     },
          new Entry(TprodE2)
     {
         Label = "ESP-2",
         ValueLabel = TprodE2.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
               new Entry(TprodE3)
     {
         Label = "ESP-3",
         ValueLabel = TprodE3.ToString(),
         Color = SKColor.Parse("#77d065")
     },
          new Entry(TprodE4)
     {
         Label = "ESP-4",
         ValueLabel = TprodE4.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
               new Entry(TprodE5)
     {
         Label = "ESP-5",
         ValueLabel = TprodE5.ToString(),
         Color = SKColor.Parse("#77d065")
     },
          new Entry(TprodE6)
     {
         Label = "ESP-6",
         ValueLabel = TprodE6.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
               new Entry(TprodE7)
     {
         Label = "ESP-7",
         ValueLabel = TprodE7.ToString(),
         Color = SKColor.Parse("#77d065")
     },
          new Entry(TprodE8)
     {
         Label = "ESP-8",
         ValueLabel = TprodE8.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
               new Entry(TprodE9)
     {
         Label = "ESP-9",
         ValueLabel = TprodE9.ToString(),
         Color = SKColor.Parse("#77d065")
     },
          new Entry(TprodE10)
     {
         Label = "ESP-10",
         ValueLabel = TprodE10.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
               new Entry(TprodE11)
     {
         Label = "ESP-11",
         ValueLabel = TprodE11.ToString(),
         Color = SKColor.Parse("#77d065")
     },
          new Entry(TprodE12)
     {
         Label = "ESP-12",
         ValueLabel = TprodE12.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
               new Entry(TprodE13)
     {
         Label = "ESP-13",
         ValueLabel = TprodE13.ToString(),
         Color = SKColor.Parse("#77d065")
     },
          new Entry(TprodE14)
     {
         Label = "ESP-14",
         ValueLabel = TprodE14.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
                    new Entry(TprodE15)
     {
         Label = "ESP-15",
         ValueLabel = TprodE15.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
                              new Entry(TprodE16)
     {
         Label = "ESP-16",
         ValueLabel = TprodE16.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
                                        new Entry(TprodE17)
     {
         Label = "ESP-17",
         ValueLabel = TprodE17.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
                                                  new Entry(TprodE18)
     {
         Label = "ESP-18",
         ValueLabel = TprodE18.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
                                                            new Entry(TprodE19)
     {
         Label = "ESP-19",
         ValueLabel = TprodE19.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },
                                                                      new Entry(TprodE20)
     {
         Label = "ESP-20",
         
         ValueLabel = TprodE20.ToString(),
         Color = SKColor.Parse("#2c3e50")
     },



};

            var chart3 = new RadarChart() { Entries = entries3 };

            charView3.Chart = chart3;
            OnAppearing();

        }


    }
}