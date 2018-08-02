using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int ID { get; set; }
        
        public Customer Customer { get; set; }

        [Required]
        public int CustomerID { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public int MovieID { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}