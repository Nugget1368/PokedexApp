using PokedexApp.Shared.Models.Pokemonss;
using System.Net;
namespace PokedexApp.Server.Services;

public class Api_Service
{
	public HttpClient Client { get; set; } = new() { BaseAddress = new Uri("https://pokeapi.co/api/v2/") };
	

	public async Task<Pokemon> GetPokemonAsync(string name)
	{
		//await Client.GetStringAsync($"{Client.BaseAddress}pokemon/{name}");
		var result = await Client.GetFromJsonAsync<Pokemon>($"{Client.BaseAddress}pokemon/{name}");
		Console.WriteLine(result.Name);
		if(result != null)
		{
			return result;
		}
		else
		{
			throw new Exception("No Pokemon Found :/");
		}
	}
}
