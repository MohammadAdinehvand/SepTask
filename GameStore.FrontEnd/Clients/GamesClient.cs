using GameStore.FrontEnd.Models;

namespace GameStore.FrontEnd.Clients
{
    public class GamesClient(HttpClient httpClient)
    {
        public async Task<GameSummary[]?> GetGamesAsync()
        {
           var response = await httpClient.GetAsync("game/games");
            if (response.IsSuccessStatusCode)
            {
                var result= await response.Content.ReadFromJsonAsync<Response<GameSummary[]>>();
                return result.Data;
            }
            return null;
        }
           

        public async Task AddGameAsync(GameDetails gameDetails)
        {
            await httpClient.PostAsJsonAsync("game", gameDetails);
        }

        public async Task<GameDetails> GetGameAsync(Guid id)
        {
            var response = await httpClient.GetAsync($"game/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Response<GameDetails>>();
                return result.Data;
            }
            return null;
        }

        public async Task UpdateGameAsync(GameDetails updateGame)
        {
            await httpClient.PutAsJsonAsync($"game", updateGame);
        }

        public async Task DeleteGameAsync(Guid id)
        {
            await httpClient.DeleteAsync($"game/{id}");

        }

    }

}
