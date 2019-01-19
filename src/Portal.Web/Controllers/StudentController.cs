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
            try
            {
                var result=await _studentService.Add(model);
                return Ok(result);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [Route("api/student")]
        [HttpDelete]
        public async Task<IActionResult> Remove(Student model)
        {
            return Ok(await _studentService.Remove(model));
        }
        [Route("api/student")]
        [HttpPut]
        public async Task<IActionResult> Update(Student model)
        {
            return Ok(await _studentService.Update(model));
        }
    }
}