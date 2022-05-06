using ISpanSTA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.ViewModel
{
    public class CExamViewModel
    {
        private TSuject _subject = null;
        private TClassCourseFullInfo _course = null;
        private TCategory _category = null;
        private TType _type = null;
       

        public CExamViewModel()
        {
            _subject = new TSuject();
            _course = new TClassCourseFullInfo();
            _category = new TCategory();
            _type = new TType();

           
        }
        public TSuject subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public TClassCourseFullInfo course
        {
            get { return _course; }
            set { _course = value; }
        }

        public TCategory category
        {
            get { return _category; }
            set { _category = value; }
        }

        public TType type
        {
            get { return _type; }
            set { _type = value; }
        }



        public int FSujectId
        {
            get { return this.subject.FSujectId; }
            set { this.subject.FSujectId = value; }
        }
        public int FCourseId
        {
            get { return this.subject.FCourseId; }
            set { this.subject.FCourseId = value; }
        }

        [DisplayName("課程")]
        public string FCourseName
        {
            get { return this.course.FCourse; }
            set { this.course.FCourse = value; }
        }
        public int FCategoryId
        {
            get { return this.subject.FCategoryId; }
            set { this.subject.FCategoryId = value; }
        }

       

        [DisplayName("題目類別")]
        public string FCategoryName
        {
            get { return this.category.FName; }
            set { this.category.FName = value; }
        }
        public int FTypeId
        {
            get { return this.subject.FTypeId; }
            set { this.subject.FTypeId = value; }
        }

        [DisplayName("題型")]
        public string FTypeName
        {
            get { return this.type.FType; }
            set { this.type.FType = value; }
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
            

    }
}
