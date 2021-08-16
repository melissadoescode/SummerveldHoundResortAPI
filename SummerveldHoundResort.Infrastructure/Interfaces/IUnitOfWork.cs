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
        IAlbumRepository Albums { get; }
        IContentRepository Contents { get; }
        IVolunteerRepository Volunteer { get; }
        IVolunteerPreferencesRepository VolunteerPreferences { get; }
    }
}
