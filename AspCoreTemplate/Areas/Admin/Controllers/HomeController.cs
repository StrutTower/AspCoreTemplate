using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreTemplate.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreTemplate.Areas.Admin.Controllers {
    [Area("Admin")]
    [Role(RoleTypes.Admin)]
    public class HomeController : CustomController {
        public IActionResult Index() {
            return View();
        }
    }
}
