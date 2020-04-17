using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeeThisMovieQuestionMark.Models
{
    [Table("movies")]
    public class Movie
    {
        [Key]
        [Required]
        public string imdb_title_id { get; set; }
        public string title { get; set; }
        public string original_title { get; set; }
        public int? year { get; set; }
        public string date_published { get; set; }
        public string genre { get; set; }
        public int? duration { get; set; }
        public string country { get; set; }
        public string language { get; set; }
        public string director { get; set; }
        public string writer { get; set; }
        public string production_company { get; set; }
        public string actors { get; set; }
        public string description { get; set; }
        public double? avg_vote { get; set; }
        public int? votes { get; set; }
        public string budget { get; set; }
        public string worlwide_gross_income { get; set; }
        public string metascore { get; set; }
        public int? reviews_from_users { get; set; }
        public int? reviews_from_critics { get; set; }
        
    }
}