using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TArtiCategory
    {
        public TArtiCategory()
        {
            TArticleInFos = new HashSet<TArticleInFo>();
        }

        public int FCategoryNumber { get; set; }
        public string FCategoryName { get; set; }

        public virtual ICollection<TArticleInFo> TArticleInFos { get; set; }
    }
}
