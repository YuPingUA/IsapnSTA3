using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TSuject
    {
        public TSuject()
        {
            TExamPaperDetails = new HashSet<TExamPaperDetail>();
            TRecords = new HashSet<TRecord>();
        }

        public int FSujectId { get; set; }
        public int FCourseId { get; set; }
        public int FCategoryId { get; set; }
        public string FQuestion { get; set; }
        public int FTypeId { get; set; }
        public string FOption1 { get; set; }
        public string FOption2 { get; set; }
        public string FOption3 { get; set; }
        public string FOption4 { get; set; }
        public int? FAns { get; set; }
        public string FAnsAnalyze { get; set; }

        public virtual TCategory FCategory { get; set; }
        public virtual TClassCourseFullInfo FCourse { get; set; }
        public virtual TType FType { get; set; }
        public virtual ICollection<TExamPaperDetail> TExamPaperDetails { get; set; }
        public virtual ICollection<TRecord> TRecords { get; set; }
    }
}
