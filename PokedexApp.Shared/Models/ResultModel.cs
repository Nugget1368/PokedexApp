using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp.Shared.Models
{
	public class ResultModel<T>
	{
		public bool Success { get; set; }
		public string ResultMessage { get; set; } = String.Empty;
		public T? Result { get; set; }
	}
}
