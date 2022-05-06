using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.ViewModel
{
    public class CategoryViewModel
    {
        public int FCategoryId { get; set; }
        public int FCourseId { get; set; }
        [DisplayName("類別名稱")]
        public string FName { get; set; }
        [DisplayName("類別內容")]
        public string FContent { get; set; }
    }
}
