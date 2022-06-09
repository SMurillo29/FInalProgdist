using System;
using System.Collections.Generic;
using System.Text;

namespace venta_vehiculos_Movile.Models
{
    class Vehiculo
    {
        public int id { get; set; }
        public double kilometraje { get; set; }
        public double precio { get; set; }
        public string color { get; set; }
        public ViewTVehiculo fktipo { get; set; }
        public Marca fkmarca { get; set; }

    }
}