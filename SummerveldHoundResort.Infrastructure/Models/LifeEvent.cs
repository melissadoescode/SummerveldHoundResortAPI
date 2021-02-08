using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models
{
    public class LifeEvent
    {
        public int LifeEventId { get; set; }
        public int DoggoId { get; set; }
        public int IconId { get; set; }
        public string LifeEventName { get; set; }
        public string LifeEventDate { get; set; }
        public DateTime LifeEventDateCreated { get; set; }
    }
}
