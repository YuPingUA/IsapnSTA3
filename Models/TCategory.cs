using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TCategory
    {
        public TCategory()
        {
            TSujects = new HashSet<TSuject>();
        }

        public int FCategoryId { get; set; }
        public int FCourseId { get; set; }
        public string FName { get; set; }
        public string FContent { get; set; }

        public virtual TClassCourseFullInfo FCourse { get; set; }
        public virtual ICollection<TSuject> TSujects { get; set; }
    }
}
