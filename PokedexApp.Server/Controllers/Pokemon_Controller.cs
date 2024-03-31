using Microsoft.AspNetCore.Mvc;
using PokedexApp.Server.Services;
using PokedexApp.Shared.Models;
using PokedexApp.Shared.Models.Pokemonss;

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
}
