using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TTeacherFullInfo
    {
        public TTeacherFullInfo()
        {
            TArrangeCourseInfos = new HashSet<TArrangeCourseInfo>();
        }

        public int FTeacherId { get; set; }
        public string FTeacherName { get; set; }
        public string FEmail { get; set; }

        public virtual ICollection<TArrangeCourseInfo> TArrangeCourseInfos { get; set; }
    }
}
