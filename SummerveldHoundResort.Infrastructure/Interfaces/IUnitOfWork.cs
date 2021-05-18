using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IDoggoRepository Doggos { get; }
        IIconRepository Icons { get; }
        ILifeEventRepository LifeEvents { get; }
        IDoggoAlbumRepository DoggoAlbums { get; }
        IDoggoContentRepository DoggoContents { get; }
        IDoggoPhotoRepository DoggoPhotos { get; }
        IDoggoVideoRepository DoggoVideos { get; }
    }
}
