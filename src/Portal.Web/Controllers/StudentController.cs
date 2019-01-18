using Microsoft.AspNetCore.Mvc;
using Portal.Application.Students;
using Portal.Domain.Entities;
using System.Threading.Tasks;

namespace Portal.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Route("api/student/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            return Ok(await _studentService.GetByClass(id));
        }

        [Route("api/student")]
        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            return Ok(await _studentService.Add(model));
        }
    }
}