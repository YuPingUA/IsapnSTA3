using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        [DisplayName("類別名稱")]
        public string FName { get; set; }
        [DisplayName("類別內容")]
        public string FContent { get; set; }

        public virtual TClassCourseFullInfo FCourse { get; set; }
        public virtual ICollection<TSuject> TSujects { get; set; }
    }
}
