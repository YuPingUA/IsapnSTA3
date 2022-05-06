using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TType
    {
        public TType()
        {
            TSujects = new HashSet<TSuject>();
        }

        public int FTypeId { get; set; }
        public string FType { get; set; }

        public virtual ICollection<TSuject> TSujects { get; set; }
    }
}
