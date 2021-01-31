using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models
{
    public class Doggo
    {
        public int DoggoId { get; set; }
        public string DoggoName { get; set; }
        public string DoggoProfilePic { get; set; }
        public string DoggoDescription { get; set; }
        public string DoggoNickname { get; set; }
        public DateTime DoggoDateCreated { get; set; }
    }
}
