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

        public UnitOfWork(IDoggoRepository doggoRepository, IIconRepository iconRepository)
        {
            Doggos = doggoRepository;
            Icons = iconRepository;
        }

        public IDoggoRepository Doggos { get; }
        public IIconRepository Icons { get; }
    }
}
