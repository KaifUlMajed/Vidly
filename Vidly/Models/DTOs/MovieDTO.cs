using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.DTOs
{
    public class MovieDTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreID { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        public byte NumberInStock { get; set; }

        [Range(0,100)]
        public byte NumberAvailable { get; set; }
    }
}
