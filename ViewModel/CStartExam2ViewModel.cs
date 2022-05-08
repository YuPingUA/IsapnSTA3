using ISpanSTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.ViewModel
{
    public class CStartExam2ViewModel
    {

        public TStudentFullInfo student { get; set; }
        public TExaminationPaper examp { get; set; }
        public List<TSuject> subject { get; set; }       
        public List<TRecord> record { get; set; }
        public int FChoose_1{ get; set; }
        public int FChoose_2 { get; set; }
        public int FChoose_3 { get; set; }
        public int FChoose_4 { get; set; }
        public int FChoose_5 { get; set; }

    }
}
