using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Students
{
    public class StudentService : IStudentService
    {
        private readonly PortalDbContext _db;

        public StudentService(PortalDbContext db)
        {
            _db = db;
        }

        public async Task<Student> Add(Student model)
        {

            var result = _db.Student.Add(model);
            await _db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Student> Get(int id)
        {
            return await _db.Student.FindAsync(id);
        }

        public async Task<IList<Student>> GetAll()
        {
            return await _db.Student.ToListAsync();
        }

        public async Task<IList<Student>> GetByClass(int classId)
        {
            return await _db.Student.Where(s=>s.ClassId==classId).ToListAsync();
        }

        public async Task<bool> Remove(Student model)
        {
            _db.Entry(model).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Student model)
        {
            _db.Student.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
