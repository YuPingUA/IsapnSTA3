using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TArrangeCourseInfo
    {
        public int FArrangeNumber { get; set; }
        public string FClassPeriod { get; set; }
        public string FCourseName { get; set; }
        public int FCourseId { get; set; }
        public int? FTeacherId { get; set; }
        public DateTime? FClassDate { get; set; }
        public decimal FTimeStart { get; set; }
        public decimal? FTimeEnd { get; set; }
        public decimal? FTeachingHours { get; set; }
        public int FRow { get; set; }
        public int FCell { get; set; }

        public virtual TClassFullInfo FClassPeriodNavigation { get; set; }
        public virtual TClassCourseFullInfo FCourse { get; set; }
        public virtual TTeacherFullInfo FTeacher { get; set; }
    }
}
