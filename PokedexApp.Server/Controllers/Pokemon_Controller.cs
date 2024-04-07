using Microsoft.AspNetCore.Mvc;
using PokedexApp.Server.Services;
using PokedexApp.Shared.Models;
using PokedexApp.Shared.Models.Pokemonss;
using PokedexApp.Shared.Models.Wrappers;

namespace PokedexApp.Server.Controllers;

[ApiController]
[Route("api/[action]")]
public class Pokemon_Controller : ControllerBase
{
	private Api_Service Service { get; set; } = new();
	[HttpGet("{name}")]
	public async Task<ResultModel<Pokemon>> Pokemon(string name)
	{
        var result = await Service.GetPokemonAsync(name);
		return result;
	}

	[HttpGet("{wrapper}")]
	public async Task<ResultModel<List<Pokemon>>> GetMore(NumberWrapper wrapper)
	{
		var result = await Service.GetMore(wrapper.FirstValue, wrapper.SecondValue);
		return result;
	}

	[HttpGet]
	public async Task<ResultModel<List<Pokemon>>> Pokemons()
	{
		var result = await Service.GetListPokemonsAsync();
		return result;
	}
}
