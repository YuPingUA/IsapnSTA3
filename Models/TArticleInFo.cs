using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TArticleInFo
    {
        public TArticleInFo()
        {
            TComments = new HashSet<TComment>();
        }

        public int FArticleNumber { get; set; }
        public int? FStudentId { get; set; }
        public string FWriter { get; set; }
        public string FTitle { get; set; }
        public string FContentf { get; set; }
        public DateTime? FReleaseTime { get; set; }
        public string FCategory { get; set; }
        public string FPhotoPath { get; set; }
        public DateTime? FModifiedTime { get; set; }
        public DateTime? FDeleteTime { get; set; }

        public virtual TArtiCategory FCategoryNavigation { get; set; }
        public virtual ICollection<TComment> TComments { get; set; }
    }
}
