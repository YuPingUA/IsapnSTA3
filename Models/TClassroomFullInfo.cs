using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TClassroomFullInfo
    {
        public TClassroomFullInfo()
        {
            TClassFullInfos = new HashSet<TClassFullInfo>();
        }

        public string FClassroom { get; set; }
        public int FClassroomNumber { get; set; }

        public virtual ICollection<TClassFullInfo> TClassFullInfos { get; set; }
    }
}
