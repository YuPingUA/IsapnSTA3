using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TEvaluationReviewHeader
    {
        public int FReviewHeaderId { get; set; }
        public int FStudentNumber { get; set; }
        public int FEvaluationId { get; set; }
        public int FEvaluationQid { get; set; }
        public decimal FRate { get; set; }
        public string FCommon { get; set; }
        public DateTime FSubmitDate { get; set; }

        public virtual TEvaluationHeader FEvaluation { get; set; }
        public virtual TStudentFullInfo FStudentNumberNavigation { get; set; }
    }
}
