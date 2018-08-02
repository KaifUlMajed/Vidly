using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.DTOs
{
    public class CustomerDTO
    {
        public int ID { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }

        [Required]
        public byte MembershipTypeID { get; set; }

        //[Is18ForMembership] 
        public DateTime? BirthDate { get; set; }
    }
}