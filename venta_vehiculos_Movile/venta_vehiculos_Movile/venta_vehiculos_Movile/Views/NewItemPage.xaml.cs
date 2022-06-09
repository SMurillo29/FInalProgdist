using System;
using System.Collections.Generic;
using System.ComponentModel;
using venta_vehiculos_Movile.Models;
using venta_vehiculos_Movile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace venta_vehiculos_Movile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}