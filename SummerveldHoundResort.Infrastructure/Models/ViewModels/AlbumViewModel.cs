using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models.ViewModels
{
    public class AlbumViewModel
    {
        public int AlbumId { get; set; }
        public int DoggoId { get; set; }
        public string AlbumName { get; set; }
        public DateTime AlbumDateCreated { get; set; }
        public string DoggoName { get; set; }
        public string DoggoProfilePic { get; set; }
        public string DoggoDescription { get; set; }
        public string DoggoNickname { get; set; }
        public DateTime DoggoDateCreated { get; set; }
    }
}
