using ISpanSTA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.ViewModel
{
    public class CStartExamViewModel
    {
        private TStudentFullInfo _student = null;
        private TExaminationPaper _examp = null;
        private TExamPaperDetail _exampd = null;
        private TSuject _subject = null;
        private TRecord _record = null;


        public CStartExamViewModel()
        {
            _student = new TStudentFullInfo();
            _examp = new TExaminationPaper();
            _exampd = new TExamPaperDetail();
            _subject = new TSuject();
            _record = new TRecord();

        }


        public TStudentFullInfo student
        {
            get { return _student; }
            set { _student = value; }
        }

        public TExaminationPaper examp
        {
            get { return _examp; }
            set { _examp = value; }
        }

        public TExamPaperDetail exampd
        {
            get { return _exampd; }
            set { _exampd = value; }
        }

        public TSuject subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public TRecord record
        {
            get { return _record; }
            set { _record = value; }
        }


        public int FRecordId
        {
            get { return this.record.FRecordId; }
            set { this.record.FRecordId = value; }
        }

        public int FStudentId
        {
            get { return this.record.FStudentId; }
            set { this.record.FStudentId = value; }
        }

        public int FExamPaperId
        {
            get { return this.record.FExamPaperId; }
            set { this.record.FExamPaperId = value; }
        }
        public int FSujectId
        {
            get { return this.record.FSujectId; }
            set { this.record.FSujectId = value; }
        }

        public DateTime? FDateTime
        {
            get { return this.record.FDateTime; }
            set { this.record.FDateTime = value; }
        }

        public int? FChoose
        {
            get { return this.record.FChoose; }
            set { this.record.FChoose = value; }
        }

        public int FEpDetailId
        {
            get { return this.exampd.FEpDetailId; }
            set { this.exampd.FEpDetailId = value; }
        }

        [DisplayName("試卷標題")]
        public string FName
        {
            get { return this.examp.FName; }
            set { this.examp.FName = value; }
        }

        [DisplayName("時間限制")]
        public int? FTimeLimit
        {
            get { return this.examp.FTimeLimit; }
            set { this.examp.FTimeLimit = value; }
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


    }
}
