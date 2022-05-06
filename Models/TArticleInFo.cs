using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TArticleInfo
    {
        public TArticleInfo()
        {
            TComments = new HashSet<TComment>();
        }

        public int FArticleId { get; set; }
        public int? FStudentNumber { get; set; }
        public string FWriter { get; set; }
        public string FTitle { get; set; }
        public string FContent { get; set; }
        public DateTime? FReleaseTime { get; set; }
        public string FCategory { get; set; }
        public string FSubCategory { get; set; }
        public string FPhotoPath { get; set; }
        public DateTime? FModifiedTime { get; set; }
        public DateTime? FDeleteTime { get; set; }
        public int? FLike { get; set; }
        public int? FComments { get; set; }
        public string FVideo { get; set; }

        public virtual TArtiCategory FCategoryNavigation { get; set; }
        public virtual ICollection<TComment> TComments { get; set; }
    }
}
