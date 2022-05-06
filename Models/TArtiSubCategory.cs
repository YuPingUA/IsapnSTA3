using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TArtiSubCategory
    {
        public int FSubCategoryId { get; set; }
        public string FCategoryName { get; set; }
        public string FSubCategoryName { get; set; }

        public virtual TArtiCategory FCategoryNameNavigation { get; set; }
    }
}
