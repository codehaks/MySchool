using Microsoft.AspNetCore.Mvc;
using Portal.Application.Students;
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

        [Route("api/studnet/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            return Ok(await _studentService.GetByClass(id));
        }
    }
}