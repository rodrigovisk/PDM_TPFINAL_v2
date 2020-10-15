using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Finalv2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP_Finalv2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDMercadoria : ContentPage
    {

        public CRUDMercadoria()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Get All Persons  
            var mercadoriaList = await App.SQLiteDb.GetItemsAsync();
            if (mercadoriaList != null)
            {
                lstMercadorias.ItemsSource = mercadoriaList;
            }
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeMercadoria.Text))
            {
                Mercadoria Mercadoria = new Mercadoria()
                {
                    NomeMercadoria = txtNomeMercadoria.Text,
                    Peso = txtPeso.Text,
                    NomeProdutor = txtNomeProdutor.Text,
                    Email = txtEmail.Text,
                    NCM = txtNCM.Text
                };

                //Add New Mercadoria  
                await App.SQLiteDb.SaveItemAsync(Mercadoria);

                Limpar();

                await DisplayAlert("Successo", "Mercadoria Cadastrada", "OK");
                //Get All Mercadorias  
                var mercadoriaList = await App.SQLiteDb.GetItemsAsync(); 
                if (mercadoriaList != null)
                {
                    lstMercadorias.ItemsSource = mercadoriaList;
                }

            }
            else
            {
                await DisplayAlert("Erro", "Insira os dados corretos", "OK");
            }
        }
        public async void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                //Get Person  
                var mercadoria = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtId.Text));
                if (mercadoria != null)
                {
                    await DisplayAlert("Mercadoria", "ID:" + mercadoria.Id + " ,Nome Mercadoria:" + mercadoria.NomeMercadoria + " ,Peso: " + mercadoria.Peso + " ,Nome Produtor: " + mercadoria.NomeProdutor + " ,Email: " + mercadoria.Email + " ,NCM: " + mercadoria.NCM, "OK");
                    
                }
            }
            else
            {
                await DisplayAlert("Erro", "É necessario o ID", "OK");
            }
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                Mercadoria mercadoria = new Mercadoria()
                {
                    Id = Convert.ToInt32(txtId.Text),
                    NomeMercadoria = txtNomeMercadoria.Text,
                    Peso = txtPeso.Text,
                    NomeProdutor = txtNomeProdutor.Text,
                    Email = txtEmail.Text,
                    NCM = txtNCM.Text
                };

                //Update Person  
                await App.SQLiteDb.SaveItemAsync(mercadoria);

                Limpar();

                await DisplayAlert("Successo", "Mercadoria Atualizada", "OK");
                //Get All Persons  
                var mercadoriaList = await App.SQLiteDb.GetItemsAsync();
                if (mercadoriaList != null)
                {
                    lstMercadorias.ItemsSource = mercadoriaList;
                }

            }
            else
            {
                await DisplayAlert("Erro", "É necessario o ID", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                //Get Person  
                var mercadoria = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtId.Text));
                if (mercadoria != null)
                {
                    //Delete Person  
                    await App.SQLiteDb.DeleteItemAsync(mercadoria);
                    await DisplayAlert("Successo", "Mercadoria Deletada", "OK");
                    Limpar();

                    //Get All Persons  
                    var mercadoriaList = await App.SQLiteDb.GetItemsAsync();
                    if (mercadoriaList != null)
                    {
                        lstMercadorias.ItemsSource = mercadoriaList;
                    }
                }
            }
            else
            {
                await DisplayAlert("Erro", "É necessario o ID", "OK");
            }

            
        }
        private void OnMercadoriaTapped(object sender, ItemTappedEventArgs args)
        {
            var selecionado = args.Item as TP_Finalv2.Models.Mercadoria;

            
            txtId.Text = selecionado.Id.ToString();
            txtNomeMercadoria.Text = selecionado.NomeMercadoria;
            txtNomeProdutor.Text = selecionado.NomeMercadoria;
            txtEmail.Text = selecionado.NomeMercadoria;
            txtPeso.Text = selecionado.NomeMercadoria;
            txtNCM.Text = selecionado.NomeMercadoria;

        }
        private void Limpar()
        {
            txtId.Text = string.Empty;
            txtNomeMercadoria.Text = string.Empty;
            txtNomeProdutor.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPeso.Text = string.Empty;
            txtNCM.Text = string.Empty;
        }
    }
}
