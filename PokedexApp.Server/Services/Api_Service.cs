using PokedexApp.Shared.Models;
using PokedexApp.Shared.Models.Pokemons;
using PokedexApp.Shared.Models.Pokemonss;
using System.Net;
namespace PokedexApp.Server.Services;

public class Api_Service
{
	public HttpClient Client { get; set; } = new() { BaseAddress = new Uri("https://pokeapi.co/api/v2/") };

	/// <summary>
	/// Gets 1 pokemon
	/// </summary>
	/// <param name="name">Name of the pokemon</param>
	/// <returns>The pokemon requested</returns>
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
	/// <summary>
	/// Gets 1 pokemon depending on id
	/// </summary>
	/// <param name="id">The id of the pokemon</param>
	/// <returns>The pokemon requested</returns>
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
	/// <summary>
	/// Gets a list of pokemons
	/// </summary>
	/// <param name="limit">Amount of pokemons</param>
	/// <param name="offset">From which pokemon-id should the loop start from</param>
	/// <returns>List of Pokemons</returns>
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
