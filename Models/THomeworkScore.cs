using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class THomeworkScore
    {
        public int FAssignmentId { get; set; }
        public int? FStudentId { get; set; }
        public int? FScore { get; set; }
        public string FStdHwFile { get; set; }
        public string FTeacherComment { get; set; }
        public int? FCourseId { get; set; }
        public DateTime? FCreateDate { get; set; }
        public DateTime? FUpdateDate { get; set; }
        public bool? FUpload { get; set; }
    }
}
