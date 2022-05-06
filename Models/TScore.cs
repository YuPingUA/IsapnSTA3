using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TScore
    {
        public int FScoreId { get; set; }
        public int? FExamPaperId { get; set; }
        public int? FStudentId { get; set; }
        public int FScore { get; set; }

        public virtual TExaminationPaper FExamPaper { get; set; }
        public virtual TStudentFullInfo FStudent { get; set; }
    }
}
