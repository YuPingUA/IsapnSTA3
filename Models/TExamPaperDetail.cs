using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TExamPaperDetail
    {
        public int FEpDetailId { get; set; }
        public int FExamPaperId { get; set; }
        public int FSujectId { get; set; }

        public virtual TExaminationPaper FExamPaper { get; set; }
        public virtual TSuject FSuject { get; set; }
    }
}
