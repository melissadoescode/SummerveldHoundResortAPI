using SummerveldHoundResort.Infrastructure.Models;
using SummerveldHoundResort.Infrastructure.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Interfaces
{
    public interface IContentRepository : IGenericRepository<Content>
    {
        Task<List<ContentViewModel>> GetByDoggoId(int albumId);    
    }
}
