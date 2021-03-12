using SummerveldHoundResort.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IDoggoRepository doggoRepository, IIconRepository iconRepository, ILifeEventRepository lifeEventRepository, IDoggoAlbumRepository doggoAlbumRepository, IDoggoContentRepository doggoContentRepository, IDoggoPhotoRepository doggoPhotoRepository)
        {
            Doggos = doggoRepository;
            Icons = iconRepository;
            LifeEvents = lifeEventRepository;
            DoggoAlbums = doggoAlbumRepository;
            DoggoContents = doggoContentRepository;
            DoggoPhotos= doggoPhotoRepository;
        }

        public IDoggoRepository Doggos { get; }
        public IIconRepository Icons { get; }
        public ILifeEventRepository LifeEvents { get; }
        public IDoggoAlbumRepository DoggoAlbums { get; }
        public IDoggoContentRepository DoggoContents{ get; }
        public IDoggoPhotoRepository DoggoPhotos{ get; }
    }
}
