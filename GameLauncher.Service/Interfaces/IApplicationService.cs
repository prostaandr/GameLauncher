﻿using GameLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Service.Interfaces
{
    public interface IApplicationService
    {
        Task<Application> GetApplication(int id);
        Task<List<Application>> GetApplications();
        Task<int> GetReviewsPersent(int id);
        Task<List<Genre>> GetGenres();
    }
}
