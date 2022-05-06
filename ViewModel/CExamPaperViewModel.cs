using ISpanSTA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.ViewModel
{
    public class CExamPaperViewModel
    {
        private TExaminationPaper _examp = null;
        private TClassFullInfo _classfi = null;
        private TClassCourseFullInfo _course = null;
        

        public CExamPaperViewModel()
        {
            _examp = new TExaminationPaper();
            _classfi = new TClassFullInfo();
            _course = new TClassCourseFullInfo();
            //_exampd = new TExamPaperDetail();
        }

        public TExaminationPaper examp
        {
            get { return _examp; }
            set { _examp = value; }
        }

        public TClassFullInfo classfi
        {
            get { return _classfi; }
            set { _classfi = value; }
        }

        public TClassCourseFullInfo course
        {
            get { return _course; }
            set { _course = value; }
        }
        //public TExamPaperDetail exampd
        //{
        //    get { return _exampd; }
        //    set { _exampd = value; }
        //}



        public int FExamPaperId
        {
            get { return this.examp.FExamPaperId; }
            set { this.examp.FExamPaperId = value; }
        }

        [DisplayName("班級")]
        public string FClassPeriod
        {
            get { return this.examp.FClassPeriod; }
            set { this.examp.FClassPeriod = value; }
        }

        public int FCourseId
        {
            get { return this.examp.FCourseId; }
            set { this.examp.FCourseId = value; }
        }

        [DisplayName("課程")]
        public string FCourseName
        {
            get { return this.course.FCourse; }
            set { this.course.FCourse = value; }
        }

        [DisplayName("試卷標題")]
        public string FName
        {
            get { return this.examp.FName; }
            set { this.examp.FName = value; }
        }

        [DisplayName("試卷描述")]
        public string FDescription
        {
            get { return this.examp.FDescription; }
            set { this.examp.FDescription = value; }
        }

        [DisplayName("開始時間")]
        public DateTime? FBegin
        {
            get { return this.examp.FBegin; }
            set { this.examp.FBegin = value; }
        }

        [DisplayName("結束時間")]
        public DateTime? FEnd
        {
            get { return this.examp.FEnd; }
            set { this.examp.FEnd = value; }
        }

        [DisplayName("時間限制")]
        public int? FTimeLimit
        {
            get { return this.examp.FTimeLimit; }
            set { this.examp.FTimeLimit = value; }
        }

        [DisplayName("公布解答")]
        public DateTime? FReveal
        {
            get { return this.examp.FReveal; }
            set { this.examp.FReveal = value; }
        }

        [DisplayName("排序")]
        public int? FOrder
        {
            get { return this.examp.FOrder; }
            set { this.examp.FOrder = value; }
        }

        //public int FCourseId
        //{
        //    get { return this.examp.FCourseId; }
        //    set { this.examp.FCourseId = value; }
        //}


    }

}
