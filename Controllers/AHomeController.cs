using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.Controllers
{
    public class AHomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }


        public IActionResult ArrangeCourse() //排課系統
        {
            return View();
        }
        public IActionResult Leave()  //出缺勤系統
        {
            return View();
        }
    }
}
