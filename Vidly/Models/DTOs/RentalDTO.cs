using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.DTOs
{
    public class RentalDTO
    {
        public int CustomerID { get; set; }
        public List<int> MovieIDs { get; set; }

    }
}