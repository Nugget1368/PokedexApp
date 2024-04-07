using PokedexApp.Shared.Models;
using PokedexApp.Shared.Models.Pokemonss;
using PokedexApp.Shared.Models.Wrappers;
using System.Net.Http.Json;

namespace PokedexApp.Client.Helpers
{
    public static class HttpHelper
    {
        public static HttpClient Client { get; set; } = new() { BaseAddress = new Uri("https://localhost:7173") };

		/// <summary>
		/// Gets 1 pokemon
		/// </summary>
		/// <param name="name">NAme of the pokemon</param>
		/// <returns>The pokemon requested</returns>
        public static async Task<ResultModel<Pokemon>> GetPokemonAsync(string name)
        {
            var response = await Client.GetAsync($"api/Pokemon/{name}");
            var result = await response.Content.ReadFromJsonAsync<ResultModel<Pokemon>>();
            return result!;
        }
		/// <summary>
		/// Gets a list of pokemons
		/// </summary>
		/// <param name="limit">Amount of pokemons</param>
		/// <param name="offset">From which pokemon-id should the loop start from</param>
		/// <returns>List of Pokemons</returns>
		public static async Task<ResultModel<List<Pokemon>>> GetListPokemonsAsync(int limit, int offset)
		{
			/*BEHÖVS skicka två siffror*/
			var response = await Client.GetAsync($"api/Pokemons?limit={limit}&offset={offset}");
			var result = await response.Content.ReadFromJsonAsync<ResultModel<List<Pokemon>>>();
			return result!;
		}

		//public static async Task<ResultModel<List<Pokemon>>> GetListPokemonsAsync()
		//{
		//	var response = await Client.GetAsync($"api/Pokemons");
		//	var result = await response.Content.ReadFromJsonAsync<ResultModel<List<Pokemon>>>();
		//	return result!;
		//}
	}
}
