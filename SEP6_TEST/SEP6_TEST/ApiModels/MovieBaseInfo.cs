using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.ApiModels
{
    public class MovieBaseInfo
    {
        public List<Poster> posters { get; set; } = new List<Poster>();
        public List<CastMember> cast { get; set; } = new List<CastMember>();
        public List<CrewMember> crew { get; set; } = new List<CrewMember>();
        public List<Review> results { get; set; } = new List<Review>();
        public List<Genre> genres { get; set; } = new List<Genre>();
        public string overview { get; set; } = "";
    }
}
