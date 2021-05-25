using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models
{
    public class Content
    {
        public int ContentId { get; set; }
        public int AlbumId { get; set; }
        public byte[] ContentUpload { get; set; }
        public string ContentDescription { get; set; }
        public DateTime ContentDateCreated { get; set; }
    }
}
