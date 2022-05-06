using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TLeaveInfo
    {
        public int FLeaveNumber { get; set; }
        public int FStudentNumber { get; set; }
        public string FLeave { get; set; }
        public DateTime? FLeaveDate { get; set; }
        public DateTime? FLeaveStart { get; set; }
        public DateTime? FLeaveEnd { get; set; }
        public int? FLeaveHours { get; set; }
        public string FStatus { get; set; }

        public virtual TStudentFullInfo FStudentNumberNavigation { get; set; }
    }
}
