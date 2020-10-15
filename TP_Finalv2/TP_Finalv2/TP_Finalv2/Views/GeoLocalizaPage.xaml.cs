using Plugin.ExternalMaps;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP_Finalv2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeoLocalizaPage : ContentPage
    {
        public GeoLocalizaPage()
        {
            InitializeComponent();
        }
        double latitude = 0;
        double longitude = 0;
        private async void btnGeolocalizacao_Clicked(object sender, EventArgs e)
        {
            lblGeolocalizacao.Text = "Obtendo a geolocalização....\n";
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync();
                lblGeolocalizacao.Text += "Status: " + position.Timestamp + "\n";
                lblGeolocalizacao.Text += "Latitude: " + position.Latitude + "\n";
                lblGeolocalizacao.Text += "Longitude: " + position.Longitude;
                latitude = position.Latitude;
                longitude = position.Longitude;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro : ", ex.Message, "OK");
            }
        }
        private void btnMostrarPosicaoNoMapa_Clicked(object sender, EventArgs e)
        {
            try
            {
                CrossExternalMaps.Current.NavigateTo("Eu", latitude, longitude);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro : ", ex.Message, "OK");
            }
        }

    }
}