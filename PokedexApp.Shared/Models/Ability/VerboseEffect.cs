using PokedexApp.Shared.Models.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp.Shared.Models.Ability
{
	public class VerboseEffect
	{
		public string Effect { get; set; }
		public string Short_effect { get; set; }
		public NamedAPIResource Language { get; set; }
	}
}
