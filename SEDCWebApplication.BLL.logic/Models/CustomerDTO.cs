using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;   

namespace SEDCWebApplication.BLL.logic.Models
{
	public class CustomerDTO
	{   [Required]
		public int? Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Address { get; set; }
        //public int ContactId { get; set; }

        public string Email { get; set; }

        public string ImagePath { get; set; }

    }
}
