using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TClassCategory
    {
        public TClassCategory()
        {
            TClassCourseFullInfos = new HashSet<TClassCourseFullInfo>();
            TClassFullInfos = new HashSet<TClassFullInfo>();
        }

        public string FClass { get; set; }
        public int FClassCategoryNumber { get; set; }

        public virtual ICollection<TClassCourseFullInfo> TClassCourseFullInfos { get; set; }
        public virtual ICollection<TClassFullInfo> TClassFullInfos { get; set; }
    }
}
