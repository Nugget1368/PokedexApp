using PokedexApp.Shared.Models;
using PokedexApp.Shared.Models.Pokemonss;
using System.Net.Http.Json;

namespace PokedexApp.Client.Helpers
{
    public static class HttpHelper
    {
        public static HttpClient Client { get; set; } = new() { BaseAddress = new Uri("https://localhost:7173") };

        public static async Task<ResultModel<Pokemon>> GetPokemonAsync(string name)
        {
            var response = await Client.GetAsync($"api/Pokemon/{name}");
            var result = await response.Content.ReadFromJsonAsync<ResultModel<Pokemon>>();
            return result!;
        }
    }
}
