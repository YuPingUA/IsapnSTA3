using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TRecord
    {
        public int FRecordId { get; set; }
        public int FStudentId { get; set; }
        public int FExamPaperId { get; set; }
        public int FSujectId { get; set; }
        public DateTime? FDateTime { get; set; }
        public int? FChoose { get; set; }

        public virtual TExaminationPaper FExamPaper { get; set; }
        public virtual TSuject FSuject { get; set; }
    }
}
