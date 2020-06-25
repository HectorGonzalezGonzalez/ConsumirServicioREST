using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace ConsumirServicioREST
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nota:Descargar Newtonsoft de nuget
            //Nota: Descargar System.Net.Http.Formatting.Extension en nuget
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44390/");

            obtenerDatosporGET(clientHttp);
            //obtenerDatosporGET_id(clientHttp);
            //guardarDatosPOST(clientHttp);
            //actualizarDatosPUT(clientHttp);
            //eliminarDatosDELETE(clientHttp);

        }
        public static void obtenerDatosporGET(HttpClient clientHttp)
        {
            var request = clientHttp.GetAsync("API/APIUsuarios").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Usuarios>>(resultString);
                foreach (Usuarios item in listado)
                {
                    Console.WriteLine(item.Nombre);
                }
            }
        }
        public static void obtenerDatosporGET_id(HttpClient clientHttp)
        {
            var requestId = clientHttp.GetAsync("API/APIUsuarios/1").Result;//Le pasamos el parametro
            if (requestId.IsSuccessStatusCode)
            {
                var resultString = requestId.Content.ReadAsStringAsync().Result;
                var dato = JsonConvert.DeserializeObject<Usuarios>(resultString);
                Console.WriteLine("Nombre:" + dato.Nombre);
            }
        }
        private static void guardarDatosPOST(HttpClient clientHttp)
        {
            Usuarios usuario = new Usuarios() {
                Nombre = "Hector master"
            , Paterno = "glez"
            , Materno = "glez2"
            , Email = "correo@dominio2.com"
            , Estatus =true
            , NombreDeUsuario = "Hgonzalez2"
            , Password = "12345"
            , Fecha_creo = DateTime.Now
            , UsrCreoId ="1"
            };
            var request = clientHttp.PostAsync("API/APIUsuarios", usuario, new JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<Boolean>(resultString);
            }

        }
        private static void actualizarDatosPUT(HttpClient clientHttp)
        {
            Usuarios usuario = new Usuarios()
            {
            Id=7
            ,    Nombre = "Hector master actualizado"
            ,
                Paterno = "glez"
            ,
                Materno = "glez2"
            ,
                Email = "correo@dominio2.com"
            ,
                Estatus = true
            ,
                NombreDeUsuario = "Hgonzalez2"
            ,
                Password = "12345"
            ,
                Fecha_creo = DateTime.Now
            ,
                UsrCreoId = "1"
            };
            var request = clientHttp.PutAsync("API/APIUsuarios", usuario, new JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<Boolean>(resultString);
            }
        }
        private static void eliminarDatosDELETE(HttpClient clientHttp)
        {
            int id = 7;
            var request = clientHttp.DeleteAsync("API/APIUsuarios?id="+id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<Boolean>(resultString);
            }
        }
    }
}
