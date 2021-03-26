using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollectionApp.Models
{
    public class Films
    {
        [Key]
        public string FilmID { get; set; } 
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent { get; set; }
        [Range(0, 25,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string Notes { get; set; }
    }
}
