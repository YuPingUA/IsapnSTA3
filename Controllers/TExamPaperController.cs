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
    public class TExamPaperController : Controller
    {
        private readonly IspanStudentSystemContext _context;

        public TExamPaperController(IspanStudentSystemContext context)
        {
            _context = context;
        }

        // GET: CExamPaperController
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

            var data = from ep in _context.TExaminationPapers
                       join cl in _context.TClassFullInfos on ep.FClassPeriod equals cl.FClassPeriod
                       join co in _context.TClassCourseFullInfos on ep.FCourseId equals co.FCourseId
                       select new CExampDetailsViewModel
                       {
                           FExamPaperId = ep.FExamPaperId,
                           FClassPeriod = ep.FClassPeriod,
                           FCourseId = ep.FCourseId,
                           FCourseName = co.FCourse,
                           FName = ep.FName,
                           FBegin = ep.FBegin,
                           FEnd = ep.FEnd,
                           FTimeLimit = ep.FTimeLimit,
                           FReveal = ep.FReveal
                       };

            List<CExampDetailsViewModel> list = new List<CExampDetailsViewModel>();
            foreach (var t in data)
                list.Add(t);
            //return View(list);


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

        }

        // GET: CExamPaperController/Details/5
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var data = from epd in _context.TExamPaperDetails
                           join ep in _context.TExaminationPapers on epd.FExamPaperId equals ep.FExamPaperId
                           join co in _context.TClassCourseFullInfos on ep.FCourseId equals co.FCourseId
                           join sj in _context.TSujects on epd.FSujectId equals sj.FSujectId
                           where epd.FExamPaperId == (int)id
                           orderby epd.FSujectId ascending //將對應的試卷題目照題目ID由小到大排序
                           select new CExampDetailsViewModel
                           {
                               FExamPaperId = epd.FExamPaperId,
                               FSujectId = epd.FSujectId,
                               FEpDetailId = epd.FEpDetailId,
                               FName = ep.FName,

                               FClassPeriod = ep.FClassPeriod,
                               FCourseId = ep.FCourseId,
                               FCourseName = co.FCourse,
                               FDescription = ep.FDescription,
                               FBegin = ep.FBegin,
                               FEnd = ep.FEnd,
                               FTimeLimit = ep.FTimeLimit,
                               FReveal = ep.FReveal,
                               FOrder = ep.FOrder,

                               FQuestion = sj.FQuestion,
                               FOption1 = sj.FOption1,
                               FOption2 =sj.FOption2,
                               FOption3 = sj.FOption3,
                               FOption4 = sj.FOption4,
                               FAns=sj.FAns,
                               FAnsAnalyze = sj.FAnsAnalyze

                              
                               //epd.FSujectId
                           };

                List<CExampDetailsViewModel> list = new List<CExampDetailsViewModel>();
                foreach (var t in data)
                    list.Add(t);
                return View(list);
            }
            return RedirectToAction("Index");
        }

        // GET: CExamPaperController/Create
        public ActionResult Create()
        {
           // TClassCourseFullInfo courseId = _context.TClassCourseFullInfo.FirstOrDefault(n => n.fName == courseName);
            int CourseId = 1; // courseId.fCourseId;

            var subjects = (from s in _context.TSujects
                              where s.FCourseId == CourseId
                              select s).ToList();
           
            //List<CExamViewModel> EpSjList = new List<CExamViewModel>() ;
            //var data = from s in _context.TSujects
            //           join c in _context.TCategories on s.FCategoryId equals c.FCategoryId
            //           join co in _context.TClassCourseFullInfos on s.FCourseId equals co.FCourseId
            //           join t in _context.TTypes on s.FTypeId equals t.FTypeId
            //           select new CExamViewModel
            //           {
            //               FSujectId = s.FSujectId,
            //               FCourseId = s.FCourseId,
            //               FCategoryId = s.FCategoryId,
            //               FTypeId = s.FTypeId,
            //               FQuestion = s.FQuestion,
            //               FCourseName = co.FCourse,
            //               FCategoryName = c.FName,
            //               FTypeName = t.FType
            //           };
            
            //foreach (var t in data)
            //    EpSjList.Add(t);
            //return View(list);

            return View();
        }


        //public int[] getSjId;
        //public IActionResult GetSjId(int[] tempSj)
        //{
        //    getSjId = tempSj;
        //    //var testc = Newtonsoft.Json.JsonConvert.SerializeObject(SjId);
        //    return Content(getSjId.ToString());
        //}

        // POST: CExamPaperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CExampDetailsViewModel ep)
        {
            try
            {
               
                TExaminationPaper ts = new TExaminationPaper();
                ts.FExamPaperId = ep.FExamPaperId;
                ts.FClassPeriod = ep.FClassPeriod;
                ts.FCourseId = ep.FCourseId;
                ts.FName = ep.FName;
                ts.FBegin = ep.FBegin;
                ts.FEnd = ep.FEnd;
                ts.FReveal = ep.FReveal;
                ts.FTimeLimit = ep.FTimeLimit;
                ts.FOrder = ep.FOrder;
                ts.FDescription = ep.FDescription;

                _context.TExaminationPapers.Add(ts);
                _context.SaveChanges();

                var tempEpId = ts.FExamPaperId;

                int[] EpSjList = ep.addSj;

               
                foreach (int s in EpSjList)
                {
                    TExamPaperDetail EpSjDetail = new TExamPaperDetail();
                    EpSjDetail.FSujectId = s;
                    EpSjDetail.FExamPaperId = tempEpId;
                    _context.TExamPaperDetails.Add(EpSjDetail);
                    _context.SaveChanges();
                }



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //ViewData["FClassPeriod"] = new SelectList(_context.TClassFullInfos, "FClassPeriod", "FClassPeriod", ep.FClassPeriod);
                //ViewData["FCourseName"] = new SelectList(_context.TClassCourseFullInfos, "FCourseId", "FCourse", ep.FCourseId);
                
                return View(ep);               
            }
        }
           



        // GET: CExamPaperController/Edit/5
        public ActionResult Edit(int? id,string clId,int? coId)
        {
            if (id != null)
            {
               
                List<TClassFullInfo> classList = new List<TClassFullInfo>();
                var classes = (from cl in _context.TClassFullInfos
                               select cl).ToList();

                foreach (var cl in classes)
                {
                    classList.Add(cl);
                }
                //找出該筆資料的班級Index對應到下拉式選單的位置
                ViewBag.clIdIndex = classList.FindIndex(cl => cl.FClassPeriod == clId);


                var classfi = _context.TClassFullInfos.FirstOrDefault(cl => cl.FClassPeriod == clId);
                string classType = classfi.FClass;                

                List<TClassCourseFullInfo> courseList = new List<TClassCourseFullInfo>();
                var course = (from co in _context.TClassCourseFullInfos
                              where co.FClass == classType
                              select co).ToList();

                foreach (var co in course)
                {
                    courseList.Add(co);
                }
                //找出該筆資料的課程Index對應到下拉式選單的位置
                ViewBag.coIdIndex = courseList.FindIndex(co => co.FCourseId == coId);


                TExaminationPaper ep = _context.TExaminationPapers.FirstOrDefault(ep => ep.FExamPaperId == (int)id);


                
                List<TSuject> subjectList = new List<TSuject>();

                //var questions = (from q in _context.TSujects
                //                 join ca in _context.TCategories on q.FCategoryId equals ca.FCategoryId
                //                 where q.FCourseId == coId
                //                 select q
                //                 ).OrderBy(q => q.FSujectId);
                //foreach (var q in questions)
                //{
                //    subjectList.Add(q);
                //}



                var epd = from t in _context.TExamPaperDetails
                          join s in _context.TSujects on t.FSujectId equals s.FSujectId
                          join c in _context.TCategories on s.FCategoryId equals c.FCategoryId
                          where t.FExamPaperId == id
                          select s;

                //var epd2 = from t in _context.TExamPaperDetails
                //          join s in _context.TSujects on t.FSujectId equals s.FSujectId
                //          join c in _context.TCategories on s.FCategoryId equals c.FCategoryId
                //          where t.FExamPaperId == id
                //          select c;
                var epdList = epd.ToList();
                List<int> sjIdBList = new List<int>();

                for(int i = 0; i < epdList.Count; i++)
                {
                    sjIdBList.Add(epdList[i].FSujectId);
                }
                int a = sjIdBList.Count;
                int[] sjIdArr = new int[a];

                for (int i = 0; i < sjIdBList.Count; i++)
                {
                    sjIdArr[i] = sjIdBList[i];
                   
                }
              
                ViewBag.sjIdBList = sjIdBList;
                ViewBag.test = sjIdBList.Count();

                //var epdd = from d in _context.TExamPaperDetails
                //          join s in _context.TSujects on d.FSujectId equals s.FSujectId
                //          join c in _context.TCategories on s.FCategoryId equals c.FCategoryId
                //          where d.FExamPaperId == id
                //          select d;

                //CExampDetailsViewModel vm = new CExampDetailsViewModel();
                //vm.examp2 = ep;
                //vm.sj2 = epd.ToList();
                //vm.epd2 = epdd.ToList();
                
                if (ep != null)
                {
                    return View(new CExampDetailsViewModel() { examp = ep });
                }
            }
            return RedirectToAction("Index");
         }
              


        // POST: CExamPaperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CExampDetailsViewModel e)
        {
            try
            {
                TExaminationPaper ep1 = _context.TExaminationPapers.FirstOrDefault(ep1 => ep1.FExamPaperId == e.FExamPaperId);
                if (ep1 != null)
                {
                    ep1.FExamPaperId = e.FExamPaperId;
                    ep1.FClassPeriod = e.FClassPeriod;
                    ep1.FCourseId = e.FCourseId;
                    ep1.FName = e.FName;
                    ep1.FBegin = e.FBegin;
                    ep1.FEnd = e.FEnd;
                    ep1.FReveal = e.FReveal;
                    ep1.FTimeLimit = e.FTimeLimit;
                    ep1.FOrder = e.FOrder;
                    ep1.FDescription = e.FDescription;


                    //所選試卷編輯前所擁有的所有題目明細
                    var BeforeEdit = from b in _context.TExamPaperDetails
                                     where b.FExamPaperId == e.FExamPaperId
                                     select b;
                    List<TExamPaperDetail> BeforeEditList = BeforeEdit.ToList();


                    var data = (from t in _context.TExamPaperDetails
                              join s in _context.TSujects on t.FSujectId equals s.FSujectId
                              join c in _context.TCategories on s.FCategoryId equals c.FCategoryId
                              where t.FExamPaperId == e.FExamPaperId
                    select s).ToList();


                    int[] EpSjListA = e.addSj; //修改後的題目ID

                    foreach (TExamPaperDetail epd in BeforeEditList)
                    {
                        int sID = epd.FSujectId; //抓出修改前的所選題目ID

                        if (!EpSjListA.Contains(sID)) //如果新的題目ID裡 沒有 舊的題目ID
                        {
                             _context.TExamPaperDetails.Remove(epd);  //將沒有的那筆舊題目移除
                            _context.SaveChanges();
                        }
                    }


                    int[] EpSjListB = new int[data.Count];
                    for(int i=0;i< data.Count; i++)
                    {
                        EpSjListB[i] = data[i].FSujectId; //抓出修改前的所選題目ID
                    }

                    

                    foreach (int aSID in EpSjListA)
                    {
                        if (!EpSjListB.Contains(aSID)) //如果舊的題目ID裡 沒有 新的題目ID
                        {
                            TExamPaperDetail EpSjDetail = new TExamPaperDetail();
                            EpSjDetail.FSujectId = aSID;
                            EpSjDetail.FExamPaperId = e.FExamPaperId;
                            _context.TExamPaperDetails.Add(EpSjDetail);
                            _context.SaveChanges();
                        }
                    }

                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(e);
            }
        }

        // GET: CExamPaperController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                TExaminationPaper ep = _context.TExaminationPapers.FirstOrDefault(ep => ep.FExamPaperId == (int)id);

                var details = from d in _context.TExamPaperDetails
                              where d.FExamPaperId == (int)id
                              select d;

                List<TExamPaperDetail> detailsList = details.ToList();

                foreach (TExamPaperDetail epd in detailsList)
                {
                    _context.TExamPaperDetails.Remove(epd);  //將明細移除
                    _context.SaveChanges();
                }
                _context.TExaminationPapers.Remove(ep);  //將試卷移除
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // POST: CExamPaperController/Delete/5
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


        ////讀出不重複的班級名稱
        public IActionResult classFilter()
        {
            var classes = _context.TClassFullInfos.Select(cl => new
            {
                cl.FClassPeriod,
                cl.FClass
            });
            /*.Distinct().OrderBy(cl => cl.FClassPeriod);*/

            return Json(classes);

        }

        ////根據班種讀出對應課程
        public IActionResult courseFilter(string classPeriod)
        {
            var classfi = _context.TClassFullInfos.FirstOrDefault(cl => cl.FClassPeriod == classPeriod);
            string classType = classfi.FClass;
            var courses = _context.TClassCourseFullInfos.
                            Where(co => co.FClass == classType).Select(co => new
                            {
                                co.FCourse,
                                co.FCourseId
                            }).Distinct();

            //var course = from s in _context.TClassCourseFullInfos
            //             join ss in _context.TClassFullInfos on s.FClass equals ss.FClass
            //             where s.FClass == classfi
            //             select new { s.FCourse, s.FCourseId };
            return Json(courses);
            //
        }


        public IActionResult ExamPshowSj(int courseId)
        {
            var questions = (from q in _context.TSujects
                            join ca in _context.TCategories on q.FCategoryId equals ca.FCategoryId
                            where q.FCourseId == courseId
                             select new
                            {
                                q.FSujectId,
                                ca.FName,
                                q.FQuestion,
                                q.FOption1,
                                q.FOption2,
                                q.FOption3,
                                q.FOption4,
                                q.FAns,
                                q.FAnsAnalyze
                            }).OrderBy(q => q.FSujectId);

            return Json(questions);

        }

        


    }
}
