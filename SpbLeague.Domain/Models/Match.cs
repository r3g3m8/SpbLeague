using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpbLeague.Domain.Models
{
	public class Match
	{
		public string Id { get; set; }
		public Team HomeTeam { get; set; }
		public Team AwayTeam { get; set; }
		public Stadium Stadium { get; set; }
		public DateOnly Date {  get; set; }
		public TimeOnly Time { get; set; }
		public string Result { get; set; }
	}
}
