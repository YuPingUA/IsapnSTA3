using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TEvaluationCheck
    {
        public int FCheckId { get; set; }
        public int FStudentNumber { get; set; }
        public int FEvaluationId { get; set; }
        public int? FSurveyStatus { get; set; }
    }
}
