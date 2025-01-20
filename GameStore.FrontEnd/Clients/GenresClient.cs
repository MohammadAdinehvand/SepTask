using GameStore.FrontEnd.Models;
using System.Net.Http.Json;

namespace GameStore.FrontEnd.Clients
{
    public class GenresClient(HttpClient httpClient)
    {
        public async Task<Genre[]> GetGenresAsync() 
        {
           var response= await httpClient.GetAsync("genre/genres");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Response<Genre[]>>();
                return result.Data;
            }
            return null;
        }
     
    }
}
