using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpbLeague.Domain.Enums
{
	public enum Position
	{
		[Display(Name = "Голкипер")]
		GK = 0,
		[Display(Name = "Защитник")]
		Defender = 1,
		[Display(Name = "Полузащитник")]
		Midfilder = 2,
		[Display(Name = "Нападающий")]
		Forward = 3,
	}
}
