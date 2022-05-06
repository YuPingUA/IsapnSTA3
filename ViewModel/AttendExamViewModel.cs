using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.ViewModel
{
    public class AttendExamViewModel
    {
        public int StudentId { get; set; }
        public string ExamName { get; set; }
        public List<QuestionAnswerViewModel> QuestionAnswer { get; set; }
        public string Message { get; set; }
    }
}
