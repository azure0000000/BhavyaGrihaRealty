using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace BBERP.Controllers
{
    public class TestController : Controller
    {
        [Authorize(Roles = "CountryMaster")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Currency")]
        public IActionResult Index1()
        {
            return View();
        }
    }
}