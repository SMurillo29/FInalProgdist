using System.ComponentModel;
using venta_vehiculos_Movile.ViewModels;
using Xamarin.Forms;

namespace venta_vehiculos_Movile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}