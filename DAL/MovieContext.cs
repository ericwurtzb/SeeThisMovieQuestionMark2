using SeeThisMovieQuestionMark.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeeThisMovieQuestionMark.DAL
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("MovieContext")
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }

}