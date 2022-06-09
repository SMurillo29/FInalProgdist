using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using venta_vehiculos_Movile.Datos.Rest;
using venta_vehiculos_Movile.Models;
using venta_vehiculos_Movile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace venta_vehiculos_Movile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaVehiculo : ContentPage
    {
        private BrockerVehiculoRest brocker = new BrockerVehiculoRest();
        public VistaVehiculo()
        {
            InitializeComponent();
            ListarTipos();
            ListarMarcas();
           
        }

        private async void ListarTipos()
        {
            BrockerTvehiculoREST bTvehiculo = new BrockerTvehiculoREST();
            cboTipo.ItemsSource = await bTvehiculo.ConsultarTodos();
        }
        private async void ListarMarcas()
        {
            BrockerMarcaRest bMarca = new BrockerMarcaRest();
            cboMarca.ItemsSource = await bMarca.ConsultarTodos();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            int id = 0;
            string textID = txtID.Text;
            if (textID != null)
            {
                if (textID != "")
                {
                    id = Convert.ToInt32(textID);
                }

            }

            double kilometraje = Convert.ToDouble(txtKilometraje.Text);
            double precio = Convert.ToDouble(txtPrecio.Text);
            string color = txtColor.Text;
            ViewTVehiculo selectedTipo = (ViewTVehiculo)cboTipo.SelectedItem;
            Marca selectedMarca = (Marca)cboMarca.SelectedItem;
            int tipo = selectedTipo.id;
            int marca = selectedMarca.id;

            //var test = cboMarca.ItemDisplayBinding;

            VehiculoViewModel vehiculo = new VehiculoViewModel();

            vehiculo.kilometraje = kilometraje;
            vehiculo.precio = precio;
            vehiculo.color = color;
            vehiculo.fktipo = tipo;
            vehiculo.fkmarca = marca;

            vehiculo.id = id;

            if (vehiculo.id == 0)
            {

                await brocker.Insertar(vehiculo);
                await DisplayAlert("Inserción de vehiculo", "Se guardó el vehiculo  " , "OK");
            }
            else
            {
                await brocker.Actualizar(vehiculo);
                await DisplayAlert("Actualización de marca", "Se Actualizó el vehiculo" , "OK");
               
            }

        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);

            Vehiculo vehiculo = new Vehiculo();
            vehiculo = await brocker.ConsultarXID(id);

            if (vehiculo != null)
            {

                txtID.Text = vehiculo.id.ToString();
                txtKilometraje.Text = vehiculo.kilometraje.ToString();
                txtColor.Text = vehiculo.color;
                txtPrecio.Text = vehiculo.precio.ToString();
                cboMarca.SelectedItem = vehiculo.fkmarca;
                cboTipo.SelectedItem = vehiculo.fktipo;
                return;
            }
            await DisplayAlert("Error", "No se encontró un vehiculo con id " + id, "OK");

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            int id = 0;           
            string textID = txtID.Text;
            if (textID != null)
            {
                id = Convert.ToInt32(textID);           
                           
                int status = await brocker.Eliminar(id);
                if (status == 0)
                {
                    await DisplayAlert("Error", "ocurrió un error al borrar" + id, "OK");
                    return;
                }
                await DisplayAlert("Borrado completo", "Se borro el vehiculo con exito ", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Debe ingresar un id " + id, "OK");
            }

        }


    }
}