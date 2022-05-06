using ISpanSTA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.ViewModel
{
    public class CExampDetailsViewModel
    {
        private TExamPaperDetail _exampd = null;
        private TExaminationPaper _examp = null;
        private TSuject _subject = null;
        private TClassFullInfo _classfi = null;
        private TClassCourseFullInfo _course = null;


        public CExampDetailsViewModel()
        {
            _exampd = new TExamPaperDetail();
            _examp = new TExaminationPaper();
            _subject = new TSuject();
            _classfi = new TClassFullInfo();
            _course = new TClassCourseFullInfo();

        }

        public TExamPaperDetail exampd
        {
            get { return _exampd; }
            set { _exampd = value; }
        }

        public TExaminationPaper examp
        {
            get { return _examp; }
            set { _examp = value; }
        }

        public TSuject subject
        {
            get { return _subject; }
            set { _subject = value; }
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






        public int FEpDetailId
        {
            get { return this.exampd.FEpDetailId; }
            set { this.exampd.FEpDetailId = value; }
        }

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

        public int FSujectId
        {
            get { return this.exampd.FSujectId; }
            set { this.exampd.FSujectId = value; }
        }

        [DisplayName("題目")]
        public string FQuestion
        {
            get { return this.subject.FQuestion; }
            set { this.subject.FQuestion = value; }
        }

        [DisplayName("選項A")]
        public string FOption1
        {
            get { return this.subject.FOption1; }
            set { this.subject.FOption1 = value; }
        }

        [DisplayName("選項B")]
        public string FOption2
        {
            get { return this.subject.FOption2; }
            set { this.subject.FOption2 = value; }
        }

        [DisplayName("選項C")]
        public string FOption3
        {
            get { return this.subject.FOption3; }
            set { this.subject.FOption3 = value; }
        }

        [DisplayName("選項D")]
        public string FOption4
        {
            get { return this.subject.FOption4; }
            set { this.subject.FOption4 = value; }
        }

        [DisplayName("答案")]
        public int? FAns
        {
            get { return this.subject.FAns; }
            set { this.subject.FAns = value; }
        }

        [DisplayName("解析")]
        public string FAnsAnalyze
        {
            get { return this.subject.FAnsAnalyze; }
            set { this.subject.FAnsAnalyze = value; }
        }

        public int[] addSj { get; set; }
        public int[] showSj { get; set; }
        public TExaminationPaper examp2 { get; set; }
        public List<TExamPaperDetail> epd2 { get; set; }
        public List<TSuject> sj2 { get; set; }
        public List<TCategory> ca2 { get; set; }
    }
}
