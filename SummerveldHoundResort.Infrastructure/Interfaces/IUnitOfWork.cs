﻿using System;
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
    }
}
