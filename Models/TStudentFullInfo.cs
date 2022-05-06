using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TStudentFullInfo
    {
        public TStudentFullInfo()
        {
            TEvaluationReviewHeaders = new HashSet<TEvaluationReviewHeader>();
            TLeaveInfos = new HashSet<TLeaveInfo>();
            TPunchInfos = new HashSet<TPunchInfo>();
            TRecords = new HashSet<TRecord>();
            TScores = new HashSet<TScore>();
        }

        public int FStudentNumber { get; set; }
        public string FStudentName { get; set; }
        public string FClassPeriod { get; set; }
        public string FGender { get; set; }
        public string FEmail { get; set; }
        public string FAccount { get; set; }
        public string FPassword { get; set; }
        public string FPhoneNumber { get; set; }
        public string FHeadShot { get; set; }

        public virtual TClassFullInfo FClassPeriodNavigation { get; set; }
        public virtual ICollection<TEvaluationReviewHeader> TEvaluationReviewHeaders { get; set; }
        public virtual ICollection<TLeaveInfo> TLeaveInfos { get; set; }
        public virtual ICollection<TPunchInfo> TPunchInfos { get; set; }
        public virtual ICollection<TRecord> TRecords { get; set; }
        public virtual ICollection<TScore> TScores { get; set; }
    }
}
