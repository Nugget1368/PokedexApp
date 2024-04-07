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

	public async Task<ResultModel<List<Pokemon>>> GetPokemonListAsync(int limit, int offset)
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
}
