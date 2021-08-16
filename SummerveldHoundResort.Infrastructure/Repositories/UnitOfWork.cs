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

        public UnitOfWork(IDoggoRepository doggoRepository, IIconRepository iconRepository, ILifeEventRepository lifeEventRepository, IAlbumRepository albumRepository, IContentRepository contentRepository, IVolunteerRepository volunteerRepository, IVolunteerPreferencesRepository volunteerPreferencesRepository)
        {
            Doggos = doggoRepository;
            Icons = iconRepository;
            LifeEvents = lifeEventRepository;
            Albums = albumRepository;
            Contents = contentRepository;
            Volunteer = volunteerRepository;
            VolunteerPreferences = volunteerPreferencesRepository;
        }

        public IDoggoRepository Doggos { get; }
        public IIconRepository Icons { get; }
        public ILifeEventRepository LifeEvents { get; }
        public IAlbumRepository Albums { get; }
        public IContentRepository Contents { get; }
        public IVolunteerRepository VolunteerRepository { get; }
        public IVolunteerRepository Volunteer { get; }
        public IVolunteerPreferencesRepository VolunteerPreferences { get; }
    }
}
