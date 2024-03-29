﻿using SummerveldHoundResort.Infrastructure.Models;
using SummerveldHoundResort.Infrastructure.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Interfaces
{
    public interface ILifeEventRepository: IGenericRepository<LifeEvent>
    {
        Task<List<LifeEventViewModel>> GetLifeEventById(int id);
    }
}
