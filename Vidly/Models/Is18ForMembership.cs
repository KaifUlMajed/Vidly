using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    // Cannot select membership other than 'Pay as you Go' if not 18 or older.
    public class Is18ForMembership : ValidationAttribute
        {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // ValidationContext contains the object of our class for whose properties we are doing validation.
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeID == MembershipType.Unknown || 
                customer.MembershipTypeID == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null) return new ValidationResult("Birth Date is required");
            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            if (age >= 18) return ValidationResult.Success;
            else return new ValidationResult("You must be atleast 18 to have a membership");
        }


    }
}