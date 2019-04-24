using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.ViewModels
{
    public class MovieGenresDirectorsRatingsFormats
    {
        public Movie Movie { get; set; }
        [DisplayName("Genres")]
        public GenreList GenreList { get; set; }
        [DisplayName("Director")]
        public DirectorList DirectorList { get; set; }
        [DisplayName("Rating")]
        public RatingList RatingList { get; set; }
        [DisplayName("Format")]
        public FormatList FormatList { get; set; }

        public IEnumerable<int> GenreIds { get; set; }
    }
}