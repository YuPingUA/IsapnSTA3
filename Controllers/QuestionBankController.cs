using ISpanSTA.Models;
using ISpanSTA.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace ISpanSTA.Controllers
{
    public class QuestionBankController : Controller
    {
        private readonly IspanStudentSystemContext _context;

        public QuestionBankController(IspanStudentSystemContext context)
        {
            _context = context;
        }
        // GET: QuestionBankController        
        public IActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var data = from s in _context.TSujects
                         join c in _context.TCategories on s.FCategoryId equals c.FCategoryId
                         join co in _context.TClassCourseFullInfos on s.FCourseId equals co.FCourseId
                         join t in _context.TTypes on s.FTypeId equals t.FTypeId
                         select new CExamViewModel { FSujectId = s.FSujectId, FCourseId = s.FCourseId, FCategoryId = s.FCategoryId, FTypeId = s.FTypeId,
                             FQuestion = s.FQuestion, FCourseName = co.FCourse, FCategoryName = c.FName, FTypeName = t.FType };

            List<CExamViewModel> list = new List<CExamViewModel>();
            foreach (var t in data)                
                list.Add(t);

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    students = students.Where(s => s.LastName.Contains(searchString)
            //                           || s.FirstMidName.Contains(searchString));
            //}
            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        students = students.OrderByDescending(s => s.LastName);
            //        break;
            //    case "Date":
            //        students = students.OrderBy(s => s.EnrollmentDate);
            //        break;
            //    case "date_desc":
            //        students = students.OrderByDescending(s => s.EnrollmentDate);
            //        break;
            //    default:  // Name ascending 
            //        students = students.OrderBy(s => s.LastName);
            //        break;
            //}

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));


            //return View(list);
        }

        // GET: QuestionBankController/Details/5
        public ActionResult Details(int? id)
        {
            //if (id != null)
            //{
            //    TSuject sj = _context.TSujects.FirstOrDefault(sj => sj.FSujectId == (int)id);
            //    if (sj != null)
            //    {
            //        return View(new CExamViewModel() { subject = sj });
            //    }
            //}
            //return RedirectToAction("Index");


            if (id != null)
            {
                var data = (from s in _context.TSujects
                           join c in _context.TCategories on s.FCategoryId equals c.FCategoryId
                           join co in _context.TClassCourseFullInfos on s.FCourseId equals co.FCourseId
                           join t in _context.TTypes on s.FTypeId equals t.FTypeId
                           where s.FSujectId == (int)id
                           select new CExamViewModel
                           {
                               FSujectId = s.FSujectId,
                               FCourseId = s.FCourseId,
                               FCategoryId = s.FCategoryId,
                               FTypeId = s.FTypeId,
                               FQuestion = s.FQuestion,
                               FCourseName = co.FCourse,
                               FCategoryName = c.FName,
                               FTypeName = t.FType,
                               FOption1 = s.FOption1,
                               FOption2 = s.FOption2,
                               FOption3 = s.FOption3,
                               FOption4 = s.FOption4,
                               FAns = s.FAns,
                               FAnsAnalyze = s.FAnsAnalyze
                           }).FirstOrDefault();

                //return View(data);
                //return View(data.ToList());
                //return View(data.ToList()[0]);
                return View(data);

            }
            return RedirectToAction("Index");

        }

        // GET: QuestionBankController/Create
        public IActionResult Create()
        {
            //ViewData["FCourseName"] = new SelectList(_context.TClassCourseFullInfos, "FCourseId", "FCourse");
            //ViewData["FCategoryName"] = new SelectList(_context.TCategories, "FCategoryId", "FName");
            ViewData["FTypeName"] = new SelectList(_context.TTypes, "FTypeId", "FType");
            return View();
        }

        // POST: QuestionBankController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CExamViewModel sj)
        {
            try
            {
                TSuject ts = new TSuject();
            ts.FCourseId = sj.FCourseId;
            ts.FCategoryId = sj.FCategoryId;
            ts.FTypeId = sj.FTypeId;
            ts.FQuestion = sj.FQuestion;
            ts.FOption1 = sj.FOption1;
            ts.FOption2 = sj.FOption2;
            ts.FOption3 = sj.FOption3;
            ts.FOption4 = sj.FOption4;
            ts.FAns = sj.FAns;
            ts.FAnsAnalyze = sj.FAnsAnalyze;

            _context.TSujects.Add(ts);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
            catch
            {
                //ViewData["FCourseName"] = new SelectList(_context.TCategories, "FCourseId", "FCourse", sj.FCourseId);
                //ViewData["FCategoryName"] = new SelectList(_context.TCategories, "FCategoryId", "FName", sj.FCategoryId);
                ViewData["FTypeName"] = new SelectList(_context.TTypes, "FTypeId", "FType", sj.FTypeId);
                return View(sj);
    }
}

        // GET: QuestionBankController/Edit/5
        public IActionResult Edit(int? id,int? coId,int? caId)
        {
            //ViewData["FCourseName"] = new SelectList(_context.TClassCourseFullInfos, "FCourseId", "FCourse");
            //ViewData["FCategoryName"] = new SelectList(_context.TCategories, "FCategoryId", "FName");
            ViewData["FTypeName"] = new SelectList(_context.TTypes, "FTypeId", "FType");

            if (id != null)
            {                
                List<TClassCourseFullInfo> courseList = new List<TClassCourseFullInfo>();
                var course = (from co in _context.TClassCourseFullInfos
                                select co).ToList(); 
                               
                foreach(var co in course)
                {
                    courseList.Add(co);
                }
                //找出該筆資料的課程Index對應到下拉式選單的位置
                ViewBag.coIdIndex = courseList.FindIndex(co=>co.FCourseId==coId);

                List<TCategory> categoryList = new List<TCategory>();
                var category = (from ca in _context.TCategories
                                where ca.FCourseId == coId
                                select ca).ToList();

                foreach (var ca in category)
                {
                    categoryList.Add(ca);
                }
                //找出該筆資料的課程類別Index對應到下拉式選單的位置
                ViewBag.caIdIndex = categoryList.FindIndex(ca => ca.FCategoryId == caId);


                TSuject sj = _context.TSujects.FirstOrDefault(sj => sj.FSujectId == (int)id);
                if (sj != null)
                {
                    return View(new CExamViewModel() { subject = sj });
                }
            }
            return RedirectToAction("Index");           
        }

        // POST: QuestionBankController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CExamViewModel sj)
        {
            try
            {
                TSuject s = _context.TSujects.FirstOrDefault(s => s.FSujectId == sj.FSujectId);
                if (s != null)
                {
                    s.FCourseId = sj.FCourseId;
                    s.FCategoryId = sj.FCategoryId;
                    s.FTypeId = sj.FTypeId;
                    s.FQuestion = sj.FQuestion;
                    s.FOption1 = sj.FOption1;
                    s.FOption2 = sj.FOption2;
                    s.FOption3 = sj.FOption3;
                    s.FOption4 = sj.FOption4;
                    s.FAns = sj.FAns;
                    s.FAnsAnalyze = sj.FAnsAnalyze;

                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                //ViewData["FCourseName"] = new SelectList(_context.TCategories, "FCourseId", "FCourse", sj.FCourseId);
                //ViewData["FCategoryName"] = new SelectList(_context.TCategories, "FCategoryId", "FName", sj.FCategoryId);
                ViewData["FTypeName"] = new SelectList(_context.TTypes, "FTypeId", "FType", sj.FTypeId);
                return RedirectToAction("Index");
            }
        }

        // GET: QuestionBankController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {               
                TSuject sj = _context.TSujects.FirstOrDefault(sj => sj.FSujectId == (int)id);
                if (sj != null)
                {
                    _context.TSujects.Remove(sj);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");            
        }

        //// POST: QuestionBankController/Delete/5
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


        //讀出不重複的課程名稱
        public IActionResult courseFilter()
        {
            var courses = _context.TClassCourseFullInfos.Select(co => new
            {
                co.FCourse,
                co.FCourseId
            }).Distinct().OrderBy(co => co.FCourseId);

            return Json(courses);

        }

        //根據課程名稱讀出對應類別
        public IActionResult categoryFilter(int courseId)
        {
            var categorys = _context.TCategories.
                            Where(ca=>ca.FCourseId == courseId).Select(ca => new
                            {                                
                                ca.FCategoryId,
                                ca.FName
                            }).Distinct();
            return Json(categorys);
        //
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

        public IActionResult Post()
        {
            
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(TCategory category)
        {
            //TCategory newcategory = new TCategory();
            //newcategory.FCourseId = category.FCourseId;
            //newcategory.FName = category.FName;
            //newcategory.FContent = category.FContent;

            _context.TCategories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Post");

        }
        

        public string Put(int id, TCategory category)
        {
            var category_ = _context.TCategories.Find(id);
            category_.FCourseId = category.FCourseId;
            category_.FName = category.FName;
            category_.FContent = category.FContent;

            //_context.Entry(category_).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return "category Updated";
        }


        public ActionResult DeleteC(int id)
        {
            TCategory category = _context.TCategories.Find(id);
            _context.TCategories.Remove(category);
            return View();
        }


    }
}
