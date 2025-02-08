﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BBERP.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Product.RoleName)]
    public class RawMaterialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}