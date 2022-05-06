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
        public decimal? Flatitude { get; set; }
        public decimal? Flatitudestart { get; set; }
        public decimal? Flatitudeend { get; set; }
        public decimal? Flongitude { get; set; }

        public virtual ICollection<TClassFullInfo> TClassFullInfos { get; set; }
    }
}
