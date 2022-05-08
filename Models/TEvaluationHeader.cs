using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TEvaluationHeader
    {
        public TEvaluationHeader()
        {
            TEvaluationDetails = new HashSet<TEvaluationDetail>();
        }

        public int FEvaluationId { get; set; }
        public string FClassId { get; set; }
        public string FCourseName { get; set; }
        public DateTime? FCreationDate { get; set; }
        public string FCreatePerson { get; set; }
        public DateTime? FLaunchDate { get; set; }
        public DateTime? FEndDate { get; set; }
        public TimeSpan? FExtensionTime { get; set; }

        public virtual ICollection<TEvaluationDetail> TEvaluationDetails { get; set; }
    }
}
