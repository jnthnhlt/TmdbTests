using System;
using System.Reflection.Metadata;

namespace TmdbData
{
    public class BelongsToCollection
    {
        public BelongsToCollection()
        {
                
        }
        public int? id { get; set; }
        public string name { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
    }
}
