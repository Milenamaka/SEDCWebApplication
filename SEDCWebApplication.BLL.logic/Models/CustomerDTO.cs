using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;

namespace SEDCWebApplication.BLL.logic.Models
{
	public class CustomerDTO
	{  
		public int? Id { get; set; }
        public string Name { get; set; }
        
        public string Address { get; set; }
        //public int ContactId { get; set; }

        public string Email { get; set; }

        public List<OrderDTO> Orders { get; set; }

        public string ImagePath { get; set; }

    }
}
