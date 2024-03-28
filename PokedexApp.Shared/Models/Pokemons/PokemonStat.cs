using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp.Shared.Models.Pokemons
{
	public class PokemonStat
	{
		public NamedAPIResource Stat {  get; set; }
		public int Effort { get; set; }
		public int Base_stat { get; set; }
	}
}
