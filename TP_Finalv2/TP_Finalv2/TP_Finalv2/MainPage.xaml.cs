using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Finalv2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP_Finalv2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void BtnCRUD_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CRUDMercadoria());
        }

        private async void BtnGeo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GeoLocalizaPage());
        }

        private async void BtnCreditos_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Autores", "Rodrigo Santos e Fabiano Dias", "ok");
        }
    }
}
