using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portal.Application.Classes
{
    public class ClassService
    {
        private readonly PortalDbContext _db;
        private readonly IMapper _mapper;

        public ClassService(PortalDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Add(Class model)
        {

            var result = _db.Classes.Add(model);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Class> Get(int bookId)
        {
            return await _db.Classes.FindAsync(bookId);
        }

        public async Task<IList<Class>> GetAll()
        {
            return await _db.Classes.ToListAsync();
        }

        public async Task<bool> Update(Class model)
        {
            _db.Classes.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }


    }
}
