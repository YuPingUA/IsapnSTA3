using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TEvaluationQuestionDetail
    {
        public TEvaluationQuestionDetail()
        {
            TEvaluationDetails = new HashSet<TEvaluationDetail>();
        }

        public int FEvaluationQid { get; set; }
        public string FDescription { get; set; }
        public int FEvaluationQtypeId { get; set; }

        public virtual TEvaluationQuestionType FEvaluationQtype { get; set; }
        public virtual ICollection<TEvaluationDetail> TEvaluationDetails { get; set; }
    }
}
