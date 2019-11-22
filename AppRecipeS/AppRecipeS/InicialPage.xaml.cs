using AppRecipeS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRecipeS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicialPage : ContentPage
    {
        List<ProdutoModel> catalogo;
        public InicialPage()
        {
            InitializeComponent();
        }
       
        private void VBusca_SearchButtonPressed(object sender, EventArgs e)
        {
            var termo = vBusca.Text;
            var consulta = catalogo.Where(p => p.Titulo.Contains(termo) || p.Descricao.Contains(termo)).ToList();
            vCatalogo.ItemsSource = consulta;
        }

        private void VCatalogo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReceitaPage());
        }
    }
}