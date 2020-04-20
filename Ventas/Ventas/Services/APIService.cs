namespace Ventas.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common.Models;
    using Newtonsoft.Json;

    public class APIService
    {
        public async Task<Response> GetList<T>(string urlBase, string prefijo, string controlador)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefijo}{controlador}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        isSuccess = false,
                        Mensaje = answer
                    };
                }

                var lista = JsonConvert.DeserializeObject<List<T>>(answer);
                return new Response
                {
                    isSuccess = true,
                    Resultado = lista
                };
            }
            catch (Exception ex)
            {

                return new Response
                {
                    isSuccess = false,
                    Mensaje = ex.Message                    
                };
            }
        }
    }
}
