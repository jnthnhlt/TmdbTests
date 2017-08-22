using System;

namespace TmdbData
{
    public class Movie
    {
        public Movie()
        {
            
        }
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public BelongsToCollection belongs_to_collection { get; set; }
        public int budget { get; set; }
        public Genre[] genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; } //minLength: 9 maxLength: 9 pattern: ^tt[0 - 9]{7}
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public ProductionCompany[] production_companies { get; set; }
        public ProductionCountry[] production_countries { get; set; }
        public string release_date { get; set; } //format: date
        public int revenue { get; set; }
        public int runtime { get; set; }
        public SpokenLanguage[] spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public AlternativeTitles alternative_titles { get; set; }
        public object images { get; set; }
    }
}
