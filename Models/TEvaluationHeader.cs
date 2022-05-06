using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TEvaluationHeader
    {
        public TEvaluationHeader()
        {
            TEvaluationDetails = new HashSet<TEvaluationDetail>();
            TEvaluationReviewHeaders = new HashSet<TEvaluationReviewHeader>();
        }

        public int FEvaluationId { get; set; }
        public string FClassPeriod { get; set; }
        public int? FCourseId { get; set; }
        public int? FTeacherId { get; set; }
        public DateTime? FCreationDate { get; set; }
        public string FCreatePerson { get; set; }
        public DateTime? FLaunchDate { get; set; }
        public DateTime? FEndDate { get; set; }
        public TimeSpan? FExtensionTime { get; set; }
        public int? FArrangeNumber { get; set; }

        public virtual TArrangeCourseInfo FArrangeNumberNavigation { get; set; }
        public virtual TClassFullInfo FClassPeriodNavigation { get; set; }
        public virtual TClassCourseFullInfo FCourse { get; set; }
        public virtual TTeacherFullInfo FTeacher { get; set; }
        public virtual ICollection<TEvaluationDetail> TEvaluationDetails { get; set; }
        public virtual ICollection<TEvaluationReviewHeader> TEvaluationReviewHeaders { get; set; }
    }
}
