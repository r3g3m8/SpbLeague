using Microsoft.AspNetCore.Identity;
using SpbLeague.Domain.Enums;

namespace SpbLeague.Domain.Models
{
	public class User : IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateOnly Birthday { get; set; }
	}
}
