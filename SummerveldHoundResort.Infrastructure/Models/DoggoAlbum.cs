using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models
{
    public class DoggoAlbum
    {
        public int DoggoAlbumId { get; set; }
        public int DoggoId { get; set; }
        public string DoggoAlbumName { get; set; }
        public string DoggoAlbumDateCreated { get; set; }
    }
}
