using ISpanSTA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.Controllers
{
    public class SHOMEController : Controller
    {
        private readonly ILogger<SHOMEController> _logger;

        public SHOMEController(ILogger<SHOMEController> logger)
        {
            _logger = logger;
        }

        public IActionResult Home()
        {
            return View();
        }

     
    }
}
