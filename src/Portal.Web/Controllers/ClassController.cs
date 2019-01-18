using Microsoft.AspNetCore.Mvc;
using Portal.Application.Classes;
using Portal.Domain.Entities;
using System.Threading.Tasks;

namespace Portal.Web.Controllers
{
    //[Route("api/[controller]")]
    public class ClassController : Controller
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [Route("api/class")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _classService.GetAll());
        }

        [Route("api/class")]
        [HttpPost]
        public async Task<IActionResult> Create(Class model)
        {
            return Ok(await _classService.Add(model));
        }

        [Route("api/class")]
        [HttpDelete]
        public async Task<IActionResult> Remove(Class model)
        {
            return Ok(await _classService.Remove(model));
        }

        [Route("api/class")]
        [HttpPut]
        public async Task<IActionResult> Update(Class model)
        {
            return Ok(await _classService.Update(model));
        }


    }
}