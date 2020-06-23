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
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("http://www.misistemaweb.com.mx/");
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
        }
    }
}
