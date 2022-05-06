using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TOption
    {
        public int FSujectId { get; set; }
        public int FOptionId { get; set; }
        public string FOption1 { get; set; }
        public string FOption2 { get; set; }
        public string FOption3 { get; set; }
        public string FOption4 { get; set; }
        public int? FAns { get; set; }
        public string FAnsAnalyze { get; set; }

        public virtual TSuject FSuject { get; set; }
    }
}
