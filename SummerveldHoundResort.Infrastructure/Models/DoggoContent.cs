using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models
{
    public class DoggoContent
    {
        public int DoggoContentId { get; set; }
        public int DoggoAlbumId { get; set; }
        public DateTime DoggoContentDateTimeCreated { get; set; }
    }
}
