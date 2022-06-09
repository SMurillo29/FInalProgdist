using System;
using venta_vehiculos_Movile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using venta_vehiculos_Movile.Datos.Rest;

namespace venta_vehiculos_Movile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaMarca : ContentPage
    {
       private BrockerMarcaRest brocker = new BrockerMarcaRest();
        public VistaMarca()
        {
            InitializeComponent();
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
            string nombre = txtNombre.Text;

            Marca marca = new Marca();

            marca.nombre_marca = nombre;
            marca.id = id;

            if (marca.id == 0)
            {
                
                await brocker.Insertar(marca);
                await DisplayAlert("Inserción de marca", "Se guardó la marca  " + nombre, "OK");
            }
            else
            {
                await brocker.Actualizar(marca);
                await DisplayAlert("Actualización de marca", "Se Actualizó la marca" + nombre, "OK");
            }

        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txtID.Text);

            Marca marca = new Marca();
            marca = await brocker.ConsultarXID(id);

            if (marca != null)
            {
                txtID.Text = marca.id.ToString();
                txtNombre.Text = marca.nombre_marca;
                return;
            }
            await DisplayAlert("Error", "No se encontró la marca con id " + id, "OK");
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            int id = 0;
            string nombre = txtNombre.Text;
            string textID = txtID.Text;
            if (textID != null)
            {
                id = Convert.ToInt32(textID);
                Marca marca = new Marca();
                marca.id = id;
                marca.nombre_marca = nombre;
                int status = await brocker.Eliminar(id);
                if (status == 0)
                {
                    await DisplayAlert("Error", "ocurrió un error al borrar" + id, "OK");
                    return;
                }
                await DisplayAlert("Borrado completo", "Se borro el tipo de marca " + nombre, "OK");
            }
            else
            {
                await DisplayAlert("Error", "Debe ingresar un id " + id, "OK");
            }

        }
    }
}