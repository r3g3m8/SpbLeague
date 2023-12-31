using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpbLeague.Domain.Models
{
	public class News
	{
		public string Id { get; set; }
		public User Author { get; set; }
		public string Title { get; set; }

		public string Content { get; set; }

		public DateOnly PublishDate { get; set; }
	}
}
