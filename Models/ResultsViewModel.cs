using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeeThisMovieQuestionMark.Models
{
    public class ResultsViewModel
    {
        //movie has pickiness level, title, and all the webservice parameters
        //extract webservice params
        //send webservice params

        //now we have pickiness level + webservice predicted rating
        //compute yes/no
        //run sql query based off of pickiness level
        //pass in pickiness level, webservice predicted rating, yes/no, and suggested movies

        public int pickiness { get; set; }
        public float predictedRating { get; set; }
        public bool shouldSee { get; set; }
        public List<Movie> suggestedMovies { get; set; }
    }
}