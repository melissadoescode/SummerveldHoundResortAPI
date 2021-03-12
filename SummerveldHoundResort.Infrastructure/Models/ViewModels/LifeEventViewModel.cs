using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models.ViewModels
{
    public class LifeEventViewModel
    {
        public int LifeEventId { get; set; }
        public int DoggoId { get; set; }
        public int IconId { get; set; }
        public string LifeEventName { get; set; }
        public string LifeEventDate { get; set; }
        public DateTime LifeEventDateCreated { get; set; }
        public string DoggoName { get; set; }
        public string DoggoProfilePic { get; set; }
        public string DoggoDescription { get; set; }
        public string DoggoNickname { get; set; }
        public DateTime DoggoDateCreated { get; set; }
        public string IconSrcUrl { get; set; }
    }
}
