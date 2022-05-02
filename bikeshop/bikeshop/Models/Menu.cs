using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using bikeshop.Models;

namespace bikeshop
{
	public class Menu
	{
	
		public int MenuId { get; set; }
		public string MenuName { get; set; }
		public List<MenuItemLink> Links { get; set; }

	}
}

