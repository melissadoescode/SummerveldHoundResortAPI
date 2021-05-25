using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int DoggoId { get; set; }
        public string AlbumName { get; set; }
        public DateTime AlbumDateCreated { get; set; }
    }
}
