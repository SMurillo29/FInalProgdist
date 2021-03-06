using System;
using System.IO;
using venta_vehiculos_Movile.Datos;
using venta_vehiculos_Movile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace venta_vehiculos_Movile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TVehiculo : ContentPage
    {
        BrockerTvehiculo brocker = new BrockerTvehiculo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "venta_vehiculos.db3"));
        public TVehiculo()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            int id=0;
            string textID = txtID.Text;
            if (textID != null)
            {
                if (textID != "")
                {
                    id = Convert.ToInt32(textID);
                }
               
            }            
            string nombre = txtNombre.Text;

            ViewTVehiculo vehiculo = new ViewTVehiculo();

            vehiculo.nombre_tipo_vehiculo = nombre;
            vehiculo.id = id;

            if (vehiculo.id == 0)
            {
                await brocker.GrabarTVehiculo(vehiculo);
                await DisplayAlert("Inserción de tipo de vehiculo", "Se guardó el tipo de vehiculo  " + nombre, "OK");
            }
            else
            {
                await brocker.GrabarTVehiculo(vehiculo);
                await DisplayAlert("Actualización de tipo de vehiculo", "Se Actualizó el tipo de vehiculo  " + nombre, "OK");
            }

        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);

            ViewTVehiculo tVehiculo = new ViewTVehiculo();
            tVehiculo = await brocker.GetTVehiculoXID(id);

            if (tVehiculo != null)
            {
                txtID.Text = tVehiculo.id.ToString();
                txtNombre.Text = tVehiculo.nombre_tipo_vehiculo;
                return;
            }
            await DisplayAlert("Error", "No se encontró el tipo de vehiculo con id " + id, "OK");

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            int id = 0;
            string nombre = txtNombre.Text;
            string textID = txtID.Text;
            if (textID != null)
            {
                id = Convert.ToInt32(textID);
                ViewTVehiculo vehiculo = new ViewTVehiculo();
                vehiculo.id = id;
                vehiculo.nombre_tipo_vehiculo = nombre;
               int status = await brocker.EliminarTVehiculo(vehiculo);
                if (status == 0)
                {
                   await DisplayAlert("Error", "ocurrió un error al borrar" + id, "OK");
                    return;
                }
                await DisplayAlert("Borrado completo", "Se borro el tipo de vehiculo " + nombre, "OK");
            }
            else
            {
                await DisplayAlert("Error", "Debe ingresar un id " + id, "OK");
            }
            



        }
    }
}