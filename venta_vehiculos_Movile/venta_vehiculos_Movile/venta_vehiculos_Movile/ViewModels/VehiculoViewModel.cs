using System;
using System.Collections.Generic;
using System.Text;

namespace venta_vehiculos_Movile.ViewModels
{
    class VehiculoViewModel
    {
        public int id { get; set; }
        public double kilometraje { get; set; }
        public double precio { get; set; }
        public string color { get; set; }
        public int fktipo { get; set; }
        public int fkmarca { get; set; }

    }
}