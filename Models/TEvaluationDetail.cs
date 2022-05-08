using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TEvaluationDetail
    {
        public int FEvaluationDetailId { get; set; }
        public int FEvaluationId { get; set; }
        public int FEvaluationQid { get; set; }

        public virtual TEvaluationHeader FEvaluation { get; set; }
        public virtual TEvaluationQuestionDetail FEvaluationQ { get; set; }
    }
}
