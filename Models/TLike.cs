using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TLike
    {
        public int FLikeNumber { get; set; }
        public int? FArticleId { get; set; }
        public int? FCommentId { get; set; }
        public int? FStudentNumber { get; set; }
        public string FArticleLike { get; set; }
        public string FCommentLike { get; set; }
    }
}
