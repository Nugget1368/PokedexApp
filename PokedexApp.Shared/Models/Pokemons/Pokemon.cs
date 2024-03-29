using PokedexApp.Shared.Models.Pokemons;
using PokedexApp.Shared.Models.Ability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp.Shared.Models.Pokemonss;

public class Pokemon
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public double Height { get; set; }
	public int Weight { get; set; }
	public PokemonCries Cries{get; set;}
	public PokemonSprites Sprites { get; set; }
	public List<PokemonType> Types { get; set; }
	public List<PokemonStat> Stats { get; set; }
	public List<NamedAPIResource> Forms { get; set; }
	public List<PokemonMove> Moves { get; set; }
}
