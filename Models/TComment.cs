using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TComment
    {
        public int FCommentsId { get; set; }
        public int? FArticleNumber { get; set; }
        public int? FStudentId { get; set; }
        public string FStudentName { get; set; }
        public string FComments { get; set; }
        public DateTime? FCommentTime { get; set; }
        public DateTime? FModifiedTime { get; set; }
        public DateTime? FDeleteTime { get; set; }

        public virtual TArticleInFo FArticleNumberNavigation { get; set; }
    }
}
