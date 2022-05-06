using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TArtiCategory
    {
        public TArtiCategory()
        {
            TArtiSubCategories = new HashSet<TArtiSubCategory>();
            TArticleInfos = new HashSet<TArticleInfo>();
        }

        public int FCategoryNumber { get; set; }
        public string FCategoryName { get; set; }

        public virtual ICollection<TArtiSubCategory> TArtiSubCategories { get; set; }
        public virtual ICollection<TArticleInfo> TArticleInfos { get; set; }
    }
}
