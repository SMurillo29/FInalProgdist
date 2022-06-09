using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using venta_vehiculos_Movile.Models;

namespace venta_vehiculos_Movile.Datos.Rest
{
    class BrockerTvehiculoREST
    {
        static readonly string BaseRest = "http://jramirgi68-001-site1.btempurl.com";
        static readonly string BaseLocal = "http://localhost:50250";
        static readonly string sRest = "/api/Tvehiculo";
        private bool Local;
        private string BaseURL;
        public BrockerTvehiculoREST()
        {
            Local = true;
        }
        public async Task<List<ViewTVehiculo>> ConsultarTodos()
        {
            if (!Local) { BaseURL = BaseRest + sRest; } else { BaseURL = BaseLocal + sRest; }
            HttpClient httpCliente = new HttpClient();
            string result = await httpCliente.GetStringAsync(BaseURL);
            //Se convierte la respuesta en objetos de la clase
            return JsonConvert.DeserializeObject<List<ViewTVehiculo>>(result);
        }
        public async Task<ViewTVehiculo> ConsultarXID(int id)
        {
            if (!Local) { BaseURL = BaseRest + sRest; } else { BaseURL = BaseLocal + sRest; }
            BaseURL += "?id=" + id;
            HttpClient httpCliente = new HttpClient();
            string result = await httpCliente.GetStringAsync(BaseURL);
            //Se convierte la respuesta en objetos de la clase
            return JsonConvert.DeserializeObject<ViewTVehiculo>(result);
        }
        public async Task<string> Insertar(ViewTVehiculo vTVehiculo)
        {
            if (!Local) { BaseURL = BaseRest + sRest; } else { BaseURL = BaseLocal + sRest; }
            HttpClient httpCliente = new HttpClient();
            var result = await httpCliente.PostAsync(BaseURL, new StringContent(JsonConvert.SerializeObject(vTVehiculo),
                    Encoding.UTF8, "application/json"));
            return await result.Content.ReadAsStringAsync();
        }
        public async Task<string> Actualizar(ViewTVehiculo vTVehiculo)
        {
            if (!Local) { BaseURL = BaseRest + sRest; } else { BaseURL = BaseLocal + sRest; }
            HttpClient httpCliente = new HttpClient();
            var result = await httpCliente.PutAsync(BaseURL, new StringContent(JsonConvert.SerializeObject(vTVehiculo),
                    Encoding.UTF8, "application/json"));
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<int> Eliminar(int id)
        {
            if (!Local) { BaseURL = BaseRest + sRest; } else { BaseURL = BaseLocal + sRest; }
            BaseURL += "?id=" + id;
            HttpClient httpCliente = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpCliente.DeleteAsync(BaseURL);
            int result = Convert.ToInt32(httpResponseMessage.IsSuccessStatusCode);
            return result;
        }
    }
}
