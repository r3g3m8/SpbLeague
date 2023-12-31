using SpbLeague.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpbLeague.Domain.Models
{
	public class Player
	{
		public string Id { get; set; }
		public Team Team { get; set; }
		public string Name { get; set; }
		public Position Position { get; set; }
		public int Number {  get; set; }

	}
}
