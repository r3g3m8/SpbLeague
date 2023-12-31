using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpbLeague.Domain.Models
{
	public class Ticket
	{
		public string Id { get; set; }
		public User User { get; set; }
		public Match Match { get; set; }
		public decimal Price { get; set; }
	}
}
