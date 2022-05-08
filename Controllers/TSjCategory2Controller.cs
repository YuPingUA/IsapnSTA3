using ISpanSTA.Models;
using ISpanSTA.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.Controllers
{
    public class TSjCategory2Controller : Controller
    {
        private readonly IspanStudentSystemContext _context;

        public TSjCategory2Controller(IspanStudentSystemContext context)
        {
            _context = context;
        }

        public IActionResult IndexC()
        {
            return View();
        }

        // GET: TSjCategory2Controller
        public IEnumerable<TCategory> Get()
        {
            return _context.TCategories.ToList();
        }

        // GET: TSjCategory2Controller/Details/5
        //public TCategory Get(int id)
        //{
        //    TCategory category = _context.TCategories.Find(id);
        //    return category;
        //}

        // GET: TSjCategory2Controller/Create
        
        public IActionResult Post(TCategory category)
        {
            //TCategory newcategory = new TCategory();
            //newcategory.FCourseId = category.FCourseId;
            //newcategory.FName = category.FName;
            //newcategory.FContent = category.FContent;

            _context.TCategories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        // POST: TSjCategory2Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TSjCategory2Controller/Edit/5
        public string Put(int id,TCategory category)
        {
            var category_ = _context.TCategories.Find(id);
            category_.FCourseId = category.FCourseId;
            category_.FName = category.FName;
            category_.FContent = category.FContent;

            //_context.Entry(category_).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return "category Updated";
        }

        // POST: TSjCategory2Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TSjCategory2Controller/Delete/5
        public ActionResult DeleteC(int id)
        {
            TCategory category = _context.TCategories.Find(id);
            _context.TCategories.Remove(category);
            return View();
        }

        // POST: TSjCategory2Controller/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
