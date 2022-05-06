using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.Controllers
{
    public class THomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
