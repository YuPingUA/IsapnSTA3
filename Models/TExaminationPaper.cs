using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TExaminationPaper
    {
        public TExaminationPaper()
        {
            TExamPaperDetails = new HashSet<TExamPaperDetail>();
            TRecords = new HashSet<TRecord>();
        }

        public int FExamPaperId { get; set; }
        public string FClassPeriod { get; set; }
        public int FCourseId { get; set; }
        public string FName { get; set; }
        public DateTime? FBegin { get; set; }
        public DateTime? FEnd { get; set; }
        public DateTime? FReveal { get; set; }
        public int? FTimeLimit { get; set; }
        public int? FOrder { get; set; }
        public string FDescription { get; set; }

        public virtual TClassFullInfo FClassPeriodNavigation { get; set; }
        public virtual TClassCourseFullInfo FCourse { get; set; }
        public virtual ICollection<TExamPaperDetail> TExamPaperDetails { get; set; }
        public virtual ICollection<TRecord> TRecords { get; set; }
    }
}
