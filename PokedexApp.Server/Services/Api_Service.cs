using PokedexApp.Shared.Models;
using PokedexApp.Shared.Models.Pokemons;
using PokedexApp.Shared.Models.Pokemonss;
using System.Net;
namespace PokedexApp.Server.Services;

public class Api_Service
{
	public HttpClient Client { get; set; } = new() { BaseAddress = new Uri("https://pokeapi.co/api/v2/") };


	public async Task<ResultModel<Pokemon>> GetPokemonAsync(string name)
	{
		var result = new ResultModel<Pokemon>();
		try
		{
			result.Result = await Client.GetFromJsonAsync<Pokemon>($"{Client.BaseAddress}pokemon/{name}");
			if (result != null)
			{
				result.Success = true;
				return result;
			}
			result.Success = false;
			return result;
		}
		catch (Exception ex)
		{
			result.Success = false;
			result.ResultMessage = ex.Message;
			return result;
		}
	}

	public async Task<ResultModel<Pokemon>> GetPokemonAsync(int id)
	{
		var result = new ResultModel<Pokemon>();
		try
		{
			result.Result = await Client.GetFromJsonAsync<Pokemon>($"{Client.BaseAddress}pokemon/{id}");
			if (result != null)
			{
				result.Success = true;
				return result;
			}
			result.Success = false;
			return result;
		}
		catch (Exception ex)
		{
			result.Success = false;
			result.ResultMessage = ex.Message;
			return result;
		}
	}

	public async Task<ResultModel<List<Pokemon>>> GetMore(int limit, int offset)
	{
		var result = new ResultModel<List<Pokemon>>();
		var pokemons = new List<Pokemon>();
		try
		{
			int amount = offset + limit;
			for (int x = offset; x < amount; x++)
			{
				var pokemonResult = await GetPokemonAsync(x);
				pokemons.Add(pokemonResult.Result);
			}
			result.Result = pokemons;
			result.Success = true;
		}
		catch (Exception ex)
		{
			result.Success = false;
			result.ResultMessage = ex.Message;
		}
		return result;
	}

	public async Task<ResultModel<List<Pokemon>>> GetListPokemonsAsync()
	{
		/*********************************************************************************************
		 * TODO
		 * Hur kan vi använda URL:en vi får i anropet?
		 * 
		 * TEORI
		 * NamedAPIResource behöver vara av typen T och url i klassen behöver oxå vara av typen T
		 * Om T då exempelvis är "Ability" eller "Pokemon" så kommer detta sättas automatiskt
		 * 
		 * PROBLEM
		 * Detta innefattar att T kommer behöva läggas till överallt där ApiResource används
		 * och nya klasser kommer behöva läggas till.
		 * 
		 * NUVARANDE PROBLEM - Denna metod
		 * Denna metod gör just nu 10 anrop till Api:et för att ta fram en lista av pokemons - INTE HÅLLBART <3
		 * Det får inte vara så, det måste lösas		 
		 *******************************************************************************************************/
		var result = new ResultModel<List<Pokemon>>();
		var pokemons = new List<Pokemon>();
		try
		{
			var resource = await Client.GetFromJsonAsync<PokemonList>($"{Client.BaseAddress}pokemon?limit=9&offset=0");
			foreach (var pokemon in resource.Results)
			{
				var temp = await GetPokemonAsync(pokemon.Name);
				var newPokemon = temp.Result;
				pokemons.Add(newPokemon);
			}
			result.Result = pokemons;
			result.Success = true;
			return result;
		}
		catch (Exception ex)
		{
			result.Success = false;
			result.ResultMessage = ex.Message;
			return result;
		}
	}
}
