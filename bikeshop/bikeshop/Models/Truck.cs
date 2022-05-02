using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace bikeshop
{
	public class Truck
	{


		public int Id { get; set; }

		DateTime Day { get; set; }

        public int MenuID { get; set; }
		public string Employee1 { get; set; }
		public string Employee2 { get; set; }
		public string Location { get; set; }

	}
}

