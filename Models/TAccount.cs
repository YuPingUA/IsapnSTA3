using System;
using System.Collections.Generic;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class TAccount
    {
        public int FAccountId { get; set; }
        public string FAccount { get; set; }
        public string FPassword { get; set; }
        public string FIdentity { get; set; }
        public string FUserName { get; set; }
        public string FHeadShot { get; set; }
        public string FEmail { get; set; }
        public string FGender { get; set; }
        public string FPhoneNumber { get; set; }
    }
}
