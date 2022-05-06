using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TFilmVideo
    {
        public int FVideoId { get; set; }
        public string FVideoFileName { get; set; }
        public DateTime? FCreateDate { get; set; }
        public DateTime? FUpdateDate { get; set; }
        public int? FTeacherId { get; set; }
        public int? FCourseId { get; set; }
        public string FLocalFile { get; set; }
        public string FYoutubeFile { get; set; }
        public string FVdoContent { get; set; }
        public int? FClassId { get; set; }
    }
}
