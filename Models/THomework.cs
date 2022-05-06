using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class THomework
    {
        public int FAssignmentId { get; set; }
        public string FHomeworkTitle { get; set; }
        public int? FTeacherId { get; set; }
        public DateTime FStartDate { get; set; }
        public DateTime FEndDate { get; set; }
        public bool FStatus { get; set; }
        public string FHwContent { get; set; }
        public string FHomeworkFile { get; set; }
        public int? FClassId { get; set; }
        public int? FCourseId { get; set; }
    }
}
