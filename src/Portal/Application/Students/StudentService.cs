using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Students
{
    public class StudentService
    {
        private readonly PortalDbContext _db;

        public StudentService(PortalDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Add(Student model)
        {

            var result = _db.Student.Add(model);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Student> Get(int id)
        {
            return await _db.Student.FindAsync(id);
        }

        public async Task<IList<Student>> GetAll()
        {
            return await _db.Student.ToListAsync();
        }

        public async Task<bool> Remove(Student model)
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
