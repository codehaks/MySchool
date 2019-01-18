﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Portal.Domain.Entities;

namespace Portal.Application.Classes
{
    public interface IClassService
    {
        Task<bool> Add(Class model);
        Task<Class> Get(int bookId);
        Task<IList<Class>> GetAll();
        Task<bool> Update(Class model);
    }
}