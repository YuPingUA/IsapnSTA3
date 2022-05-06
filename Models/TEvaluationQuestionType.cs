using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TEvaluationQuestionType
    {
        public TEvaluationQuestionType()
        {
            TEvaluationQuestionDetails = new HashSet<TEvaluationQuestionDetail>();
        }

        public int FEvaluationQtypeId { get; set; }
        public string FQtypeName { get; set; }

        public virtual ICollection<TEvaluationQuestionDetail> TEvaluationQuestionDetails { get; set; }
    }
}
