﻿using ISpanSTA.Models;
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
        private readonly dbIspanStudentSystemContext _context;

        public SExamIndexController(dbIspanStudentSystemContext context)
        {
            _context = context;
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




        public IActionResult StartExam4(int? id)
        {
            if (id != null)
            {
                //TExaminationPaper ep = _context.TExaminationPapers.FirstOrDefault(ep => ep.FExamPaperId == (int)id);

                var data = (from epd in _context.TExamPaperDetails
                           join ep in _context.TExaminationPapers on epd.FExamPaperId equals ep.FExamPaperId
                           join s in _context.TSujects on epd.FSujectId equals s.FSujectId
                           where epd.FExamPaperId == (int)id
                            orderby s.FSujectId
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
        public IActionResult StartExam4(CStartExam2ViewModel rc)
        {
            //int totalcount = rc.subject.Count();
            try
            {
                //List<TRecord> list = new List<TRecord>();
                //for (int i = 0; i < totalcount; i++)
                //{
                    TRecord ts = new TRecord();
                    ts.FStudentId = rc.FStudentId;
                    ts.FExamPaperId = rc.FExamPaperId;
                    ts.FSujectId = rc.FSujectId;
                    ts.FDateTime = DateTime.Now;
                    ts.FChoose = rc.FChoose;
                    
                //}

                _context.TRecords.Add(ts);

                _context.SaveChanges();
                return Content("111");
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(rc);
            }
        }

               
        public IActionResult CalcScore(int? stuId, int? epId)
        {
            var dataRc = (from r in _context.TRecords
                       where r.FStudentId == 5 && r.FExamPaperId == (int)epId
                       orderby r.FSujectId
                       select r).ToList(); //抓出A學生填寫a試卷的題目作答紀錄

            List<TRecord> rc = new List<TRecord>();
            foreach (var drc in dataRc)
            {
                rc.Add(drc);
            }

            var sj = (from epd in _context.TExamPaperDetails
                      join ep in _context.TExaminationPapers on epd.FExamPaperId equals ep.FExamPaperId
                      join s in _context.TSujects on epd.FSujectId equals s.FSujectId
                      where epd.FExamPaperId == (int)epId
                      orderby s.FSujectId
                      select s).ToList();



            //List<TSuject> sj = new List<TSuject>();
            //foreach (var dsj in dataSj)
            //{
            //    sj.Add(dsj);
            //}


            List<int> bingo = new List<int>();

            for (int i = 0; i < sj.Count; i++)
            {
                if (dataRc[i].FChoose == sj[i].FAns)
                {
                    bingo.Add(i); //答對的題目(從0開始) .count答對數
                }
            }


            ViewBag.bingoList = bingo;
            ViewBag.bingoCount = bingo.Count;

            int scoreTotal = (int)((100 / sj.Count) * bingo.Count);

            TScore sc = new TScore();
            sc.FStudentId = stuId;
            sc.FExamPaperId = epId;
            sc.FScore = scoreTotal;

            _context.TScores.Add(sc);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult epResult(int? id,int? stuId=5)
        {
            if (id != null)
            {
                var sj = (from epd in _context.TExamPaperDetails
                            join ep in _context.TExaminationPapers on epd.FExamPaperId equals ep.FExamPaperId
                            join s in _context.TSujects on epd.FSujectId equals s.FSujectId
                            where epd.FExamPaperId == (int)id
                            orderby s.FSujectId
                            select s).ToList();

                CStartExam2ViewModel SEVM = new CStartExam2ViewModel();

                SEVM.subject = sj;
                SEVM.student = _context.TStudentFullInfos.FirstOrDefault(s => s.FStudentNumber == 5);//這邊要改判斷哪位學生
                SEVM.examp = _context.TExaminationPapers.FirstOrDefault(ep => ep.FExamPaperId == (int)id);

                var rc = (from r in _context.TRecords
                         join ep in _context.TExaminationPapers on r.FExamPaperId equals ep.FExamPaperId
                         join stu in _context.TStudentFullInfos on r.FStudentId equals stu.FStudentNumber
                         join s in _context.TSujects on r.FSujectId equals s.FSujectId
                         where r.FExamPaperId == (int)id && r.FStudentId == (int)stuId
                          orderby r.FSujectId
                          select r).ToList();
                
                SEVM.record = rc;

                SEVM.scoreD = _context.TScores.FirstOrDefault(sc => sc.FExamPaperId == id && sc.FStudentId == stuId);



                var dataRc = (from r in _context.TRecords
                              where r.FStudentId == 5 && r.FExamPaperId == (int)id
                              orderby r.FSujectId
                              select r).ToList(); //抓出A學生填寫a試卷的題目作答紀錄

                List<TRecord> rc2 = new List<TRecord>();
                foreach (var drc in dataRc)
                {
                    rc.Add(drc);
                }

                //var dataSj = (from s in _context.TSujects
                //              join r in _context.TRecords on s.FSujectId equals r.FSujectId
                //              orderby s.FSujectId
                //              select s).ToList(); //抓出試卷題目

                //List<TSuject> sj2 = new List<TSuject>();
                //foreach (var dsj in sj)
                //{
                //    sj.Add(dsj);
                //}


                List<int> bingo = new List<int>();

                for (int i = 0; i < sj.Count; i++)
                {
                    if (dataRc[i].FChoose == sj[i].FAns)
                    {
                        bingo.Add(i); //答對的題目(從0開始) .count答對數
                    }
                }

                SEVM.bingo = bingo;



                return View(SEVM);
            }
               



            return View();
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


        public IActionResult Index2()
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


    }
}
