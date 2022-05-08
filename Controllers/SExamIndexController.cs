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
    public class SExamIndexController : Controller
    {
        private readonly IspanStudentSystemContext _context;

        public SExamIndexController(IspanStudentSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index2()
        {
            return View();
        }

        // GET: SExamIndexController
        public IActionResult Index() //TStudentFullInfo s
        {            
            var data = from ep in _context.TExaminationPapers
                       join cl in _context.TClassFullInfos on ep.FClassPeriod equals cl.FClassPeriod
                       join co in _context.TClassCourseFullInfos on ep.FCourseId equals co.FCourseId
                       where cl.FClassPeriod == "MSIT40"    //s.FClassPeriod
                       select new CExamPaperViewModel
                       {
                           FExamPaperId = ep.FExamPaperId,
                           FClassPeriod = ep.FClassPeriod,
                           FCourseId = ep.FCourseId,
                           FCourseName = co.FCourse,
                           FName = ep.FName,
                           FBegin = ep.FBegin,
                           FEnd = ep.FEnd,
                           FTimeLimit = ep.FTimeLimit,
                           FReveal = ep.FReveal,
                           FDescription = ep.FDescription
                           
                       };

            List<CExamPaperViewModel> list = new List<CExamPaperViewModel>();
            foreach (var t in data)
                list.Add(t);

            return View(list);
           
        }

        // GET: SExamIndexController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SExamIndexController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SExamIndexController/Create
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

        // GET: SExamIndexController/Edit/5
        public IActionResult StartExam3(int? id)
        {
            //if (id != null)
            //{
            //    var data = from epd in _context.TExamPaperDetails
            //               join ep in _context.TExaminationPapers on epd.FExamPaperId equals ep.FExamPaperId
            //               join s in _context.TSujects on epd.FSujectId equals s.FSujectId
            //               where epd.FExamPaperId == (int)id
            //               select new CStartExamViewModel
            //               {
            //                   FExamPaperId = epd.FExamPaperId,
            //                   FEpDetailId = epd.FEpDetailId,
            //                   FSujectId = s.FSujectId,
            //                   FQuestion = s.FQuestion,
            //                   FOption1 = s.FOption1,
            //                   FOption2 = s.FOption2,
            //                   FOption3 = s.FOption3,
            //                   FOption4 = s.FOption4,
            //                   FName = ep.FName,
            //                   FTimeLimit = ep.FTimeLimit

            //               };

            //    List<CStartExamViewModel> list = new List<CStartExamViewModel>();

            //    foreach (var t in data)
            //        list.Add(t);

            //List < TSuject > EpQuestion = new List<TSuject>();

            if (id != null)
            {
                TExaminationPaper ep = _context.TExaminationPapers.FirstOrDefault(ep => ep.FExamPaperId == (int)id);
                if (ep != null)
                {
                    return View(new CStartExamViewModel() { examp = ep });
                }
            }

            return RedirectToAction("Index");

            //return View();
        }  
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StartExam3(CStartExamViewModel rc)
        {
            try
            {
                TRecord ts = new TRecord();
                //ts.FRecordId = rc.FRecordId;
                ts.FStudentId = rc.FStudentId;
                ts.FExamPaperId = rc.FExamPaperId;
                ts.FSujectId = rc.FSujectId;
                ts.FDateTime = DateTime.Now;
                ts.FChoose = rc.FChoose;

                _context.TRecords.Add(ts);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(rc);
            }
        }





        public IActionResult StartExam4(int? id)
        {
            if (id != null)
            {
                //TExaminationPaper ep = _context.TExaminationPapers.FirstOrDefault(ep => ep.FExamPaperId == (int)id);

                var data = (from epd in _context.TExamPaperDetails
                           join ep in _context.TExaminationPapers on epd.FExamPaperId equals ep.FExamPaperId
                           join s in _context.TSujects on epd.FSujectId equals s.FSujectId
                           where epd.FExamPaperId == (int)id
                           select s).ToList();
                    CStartExam2ViewModel SEVM = new CStartExam2ViewModel();
                
                SEVM.subject = data;

                SEVM.student = _context.TStudentFullInfos.FirstOrDefault(s => s.FStudentNumber == 5);//這邊要改判斷哪位學生 

                SEVM.examp = _context.TExaminationPapers.FirstOrDefault(ep => ep.FExamPaperId == id);               
                 
                    return View(SEVM);
                
            }

            return RedirectToAction("Index");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StartExam4(CStartExam2ViewModel rc)
        {
            int totalcount = rc.subject.Count();
            try
            {
                List<TRecord> list = new List<TRecord>();
                for (int i = 0; i < totalcount; i++)
                {
                    TRecord ts = new TRecord();
                    ts.FStudentId = rc.student.FStudentNumber;
                    ts.FExamPaperId = rc.examp.FExamPaperId;
                    ts.FSujectId = rc.subject[i].FSujectId;
                    ts.FDateTime = DateTime.Now;
                    ts.FChoose = rc.FChoose_1;
                    list.Add(ts);
                }

                //_context.TRecords.Add(list);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(rc);
            }
        }


        // POST: SExamIndexController/Edit/5
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

        // GET: SExamIndexController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SExamIndexController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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


    }
}
