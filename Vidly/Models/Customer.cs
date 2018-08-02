using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Display(Name="Subscribe to Newsletter?")]
        public bool IsSubscribed { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        [Required]
        public byte MembershipTypeID { get; set; }

        // ? means that the BirthDate is nullable.
        [Display(Name="Date of Birth")]
        //[Is18ForMembership]
        public DateTime? BirthDate { get; set; }
    }
}