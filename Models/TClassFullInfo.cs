using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TClassFullInfo
    {
        public TClassFullInfo()
        {
            TArrangeCourseInfos = new HashSet<TArrangeCourseInfo>();
            TExaminationPapers = new HashSet<TExaminationPaper>();
            TStudentFullInfos = new HashSet<TStudentFullInfo>();
        }

        public int FClassNumber { get; set; }
        public string FClass { get; set; }
        public string FClassPeriod { get; set; }
        public string FMentorName { get; set; }
        public string FClassroom { get; set; }
        public DateTime? FClassStartTime { get; set; }
        public DateTime? FClassEndTime { get; set; }

        public virtual TClassCategory FClassNavigation { get; set; }
        public virtual TClassroomFullInfo FClassroomNavigation { get; set; }
        public virtual ICollection<TArrangeCourseInfo> TArrangeCourseInfos { get; set; }
        public virtual ICollection<TExaminationPaper> TExaminationPapers { get; set; }
        public virtual ICollection<TStudentFullInfo> TStudentFullInfos { get; set; }
    }
}
