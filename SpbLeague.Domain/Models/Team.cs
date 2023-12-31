using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpbLeague.Domain.Models
{
	public class Team
	{
		public string Id { get; set; }
		public Stadium Stadium { get; set; }
		public string Name { get; set; }
		public string CoachName { get; set; }


	}
}
