using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portal.Application.Classes
{
    public class ClassService : IClassService
    {
        private readonly PortalDbContext _db;
        //private readonly IMapper _mapper;
        private readonly ClassValidator _validator;

        public ClassService(PortalDbContext db, ClassValidator validator)
        {
            _db = db;
            _validator = validator;
        }

        public async Task<Class> Add(Class model)
        {
            
            var result = _db.Class.Add(model);
            await _db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Class> Get(int id)
        {
            return await _db.Class.FindAsync(id);
        }

        public async Task<IList<Class>> GetAll()
        {
            return await _db.Class.ToListAsync();
        }

        public async Task<bool> Remove(Class model)
        {
            _db.Entry(model).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Class model)
        {
            _db.Class.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }


    }
}
