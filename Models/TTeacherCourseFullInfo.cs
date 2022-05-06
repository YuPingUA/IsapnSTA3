using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TTeacherCourseFullInfo
    {
        public int FCourseId { get; set; }
        public string FTeacherName { get; set; }
        public int? FTeacherId { get; set; }
        public int FTeacherCourseId { get; set; }

        public virtual TClassCourseFullInfo FCourse { get; set; }
    }
}
