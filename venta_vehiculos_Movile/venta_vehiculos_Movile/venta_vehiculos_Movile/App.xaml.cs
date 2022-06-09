using System;
using System.IO;
using venta_vehiculos_Movile.Datos;
using venta_vehiculos_Movile.Services;
using venta_vehiculos_Movile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace venta_vehiculos_Movile
{
    public partial class App : Application
    {

        private clsBasesDatos _BaseDatos;
        public clsBasesDatos BaseDatos
        {
            get
            {
                if (_BaseDatos == null)
                {
                    _BaseDatos = new clsBasesDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "venta_vehiculos.db3"));
                }
                return _BaseDatos;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            BaseDatos.CrearTablas();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
