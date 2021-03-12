using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models
{
    public class DoggoPhoto
    {
        public int DoggoPhotoId { get; set; }
        public int DoggoContentId { get; set; }
        public string DoggoPhotoUrl { get; set; }
        public string DoggoPhotoDescription { get; set; }
    }
}
