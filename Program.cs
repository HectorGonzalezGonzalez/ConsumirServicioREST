using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ConsumirServicioREST
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nota:Descargar Newtonsoft de nuget
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("http://www.misistemaweb.com.mx/");
            /*Metodo GET*/
            var request = clientHttp.GetAsync("API/APIUsuarios").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Usuario>>(resultString);
                foreach (Usuario item in listado)
                {
                    Console.WriteLine(item.Nombre);
                }                
            }
            /*Metodo GET ID*/
            var requestId = clientHttp.GetAsync("API/APIUsuarios/1").Result;//Le pasamos el parametro
            if (requestId.IsSuccessStatusCode)
            {
                var resultString = requestId.Content.ReadAsStringAsync().Result;
                var dato = JsonConvert.DeserializeObject<Usuario>(resultString);
                Console.WriteLine("Nombre:" + dato.Nombre);
            }
        }
        
    }
}
