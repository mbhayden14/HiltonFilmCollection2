using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiltonFilmCollection2.Models
{
    public class FilmItem
    {
        //Class that stores the information of each film
        [Key]
        [Required]
        public int FilmId { get; set; }
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1880, 2100, ErrorMessage = "Please enter a valid year.")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Please enter a director.")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Please select a rating.")]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
