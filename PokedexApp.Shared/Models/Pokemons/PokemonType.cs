using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp.Shared.Models.Pokemons
{
    public class PokemonType
    {
        public int Slot { get; set; }
        public NamedAPIResource? Type { get; set; }
    }
}
