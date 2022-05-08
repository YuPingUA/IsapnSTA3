using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TPunchInfo
    {
        public int FPunchNumber { get; set; }
        public int FStudentNumber { get; set; }
        public DateTime? FClassDate { get; set; }
        public decimal? FTimeStart { get; set; }
        public DateTime? FPunchTime { get; set; }
        public string FPunchLocation { get; set; }
        public int? FAbsenceHours { get; set; }

        public virtual TStudentFullInfo FStudentNumberNavigation { get; set; }
    }
}
