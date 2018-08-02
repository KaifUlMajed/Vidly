using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public byte ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //public static readonly byte Comedy = 1;
        //public static readonly byte Horror = 2;
        //public static readonly byte Romance = 3;
        //public static readonly byte Action = 4;
        //public static readonly byte Thriller = 5;

    }
}