using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TStudentFullInfo
    {
        public TStudentFullInfo()
        {
            TLeaveInfos = new HashSet<TLeaveInfo>();
            TPunchInfos = new HashSet<TPunchInfo>();
        }

        public int FStudentNumber { get; set; }
        public string FStudentName { get; set; }
        public string FClassPeriod { get; set; }
        public string FGender { get; set; }
        public string FEmail { get; set; }
        public string FAccount { get; set; }
        public string FPassword { get; set; }
        public string FPhoneNumber { get; set; }
        public byte[] FHeadShot { get; set; }

        public virtual TClassFullInfo FClassPeriodNavigation { get; set; }
        public virtual ICollection<TLeaveInfo> TLeaveInfos { get; set; }
        public virtual ICollection<TPunchInfo> TPunchInfos { get; set; }
    }
}
