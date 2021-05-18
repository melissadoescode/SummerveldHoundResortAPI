using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models
{
    public class DoggoVideo
    {
        public int DoggoVideoId { get; set; }
        public int DoggoContentId { get; set; }
        public string DoggoVideoUrl { get; set; }
        public string DoggoVideoDescription { get; set; }
    }
}
