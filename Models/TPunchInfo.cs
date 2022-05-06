using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TPunchInfo
    {
        public int FPunchNumber { get; set; }
        public int FStudentNumber { get; set; }
        public DateTime FTimeStart { get; set; }
        public string FPunchStatus { get; set; }

        public virtual TStudentFullInfo FStudentNumberNavigation { get; set; }
    }
}
