using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models.ViewModels
{
    public class ContentViewModel
    {
        public int ContentId { get; set; }
        public int AlbumId { get; set; }
        public string ContentUpload { get; set; }
        public string ContentDescription { get; set; }
        public DateTime ContentDateCreated { get; set; }
        public int DoggoId { get; set; }
        public string AlbumName { get; set; }
        public DateTime AlbumDateCreated { get; set; }
    }
}
