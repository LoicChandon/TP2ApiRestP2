using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TP2ApiRest.Models.EntityFramework;

namespace TP2ApiRestP2.Services
{
    public class WSService : IService
    {
        string uri = new string("http://localhost:12278/api/");
        HttpClient client = new HttpClient();
        public WSService(string uri)
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<bool> DeleteSerieAsync(string nomControleur)
        {
            var response = await client.DeleteAsync(nomControleur);
            try
            {
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        public Task<bool> DeleteSerieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Serie>> GetAll(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Serie> GetSerieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PostSerieAsync(string nomControleur, Serie serie)
        {
            throw new NotImplementedException();
            //var response = await client.PostAsync(nomControleur, serie);
            //try
            //{
            //    response.EnsureSuccessStatusCode();
            //    return true;
            //}
            //catch (HttpRequestException)
            //{
            //    return false;
            //}
        }

        public async Task<bool> PutSerieAsync(Serie serie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutSerieAsync(string nomControleur)
        {
            throw new NotImplementedException();
        }
    }
}
