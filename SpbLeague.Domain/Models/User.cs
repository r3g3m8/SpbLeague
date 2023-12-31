using SpbLeague.Domain.Enums;

namespace SpbLeague.Domain.Models
{
	public class User
	{
		public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
		public DateOnly Birthday { get; set; }
		public Role Role { get; set; }
	}
}
