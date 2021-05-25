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

        public UnitOfWork(IDoggoRepository doggoRepository, IIconRepository iconRepository, ILifeEventRepository lifeEventRepository, IAlbumRepository albumRepository, IContentRepository contentRepository)
        {
            Doggos = doggoRepository;
            Icons = iconRepository;
            LifeEvents = lifeEventRepository;
            Albums = albumRepository;
            Contents = contentRepository;
        }

        public IDoggoRepository Doggos { get; }
        public IIconRepository Icons { get; }
        public ILifeEventRepository LifeEvents { get; }
        public IAlbumRepository Albums { get; }
        public IContentRepository Contents { get; }
    }
}
