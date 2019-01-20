using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portal.Application.Students;
using Portal.Domain.Entities;
using System.Threading.Tasks;

namespace Portal.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ILogger _logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
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
                var result = await _studentService.Add(model);
                _logger.LogInformation(model.ToString() + " Created");
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(model.ToString() + $" not created with exception : {ex.Message}");

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