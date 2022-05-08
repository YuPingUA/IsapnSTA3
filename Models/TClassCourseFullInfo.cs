using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TClassCourseFullInfo
    {
        public TClassCourseFullInfo()
        {
            TArrangeCourseInfos = new HashSet<TArrangeCourseInfo>();
            TCategories = new HashSet<TCategory>();
            TExaminationPapers = new HashSet<TExaminationPaper>();
            TSujects = new HashSet<TSuject>();
            TTeacherCourseFullInfos = new HashSet<TTeacherCourseFullInfo>();
        }

        public int FCourseId { get; set; }
        public string FCourse { get; set; }
        public int? FCourseHours { get; set; }
        public string FClass { get; set; }

        public virtual TClassCategory FClassNavigation { get; set; }
        public virtual ICollection<TArrangeCourseInfo> TArrangeCourseInfos { get; set; }
        public virtual ICollection<TCategory> TCategories { get; set; }
        public virtual ICollection<TExaminationPaper> TExaminationPapers { get; set; }
        public virtual ICollection<TSuject> TSujects { get; set; }
        public virtual ICollection<TTeacherCourseFullInfo> TTeacherCourseFullInfos { get; set; }
    }
}
