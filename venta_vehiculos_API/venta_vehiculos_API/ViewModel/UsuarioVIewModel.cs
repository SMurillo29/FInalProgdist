using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace venta_vehiculos_API.ViewModel
{
    public class UsuarioVIewModel
    {
        public int id { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public int FKrol { get; set; }
    }
}