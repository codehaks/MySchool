using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Classes;

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
    }
}