using System.Collections.Generic;
using System.Threading.Tasks;
using Portal.Domain.Entities;

namespace Portal.Application.Students
{
    public interface IStudentService
    {
        Task<bool> Add(Student model);
        Task<Student> Get(int id);
        Task<IList<Student>> GetAll();
        Task<IList<Student>> GetByClass(int classId);
        Task<bool> Remove(Student model);
        Task<bool> Update(Class model);
    }
}