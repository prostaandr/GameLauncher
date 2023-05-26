﻿using GameLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Data.Interfaces
{
    public interface IApplicationRepository : IBaseRepository<Application>
    {
        IQueryable<Application> GetAll(string searchValue);
    }
}
