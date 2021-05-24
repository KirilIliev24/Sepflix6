using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.ApiModels
{
    public class MovieBaseInfo
    {
        public Image image { get; set; } = new Image();
        public string titleType { get; set; } = "";
    }
}
