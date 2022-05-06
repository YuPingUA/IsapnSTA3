using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISpanSTA.ViewModel
{
    public class QuestionAnswerViewModel
    {
        public QuestionAnswerViewModel()
        {

        }
        public int Id { get; set; }
        
        [Display(Name = "Exam")]
        public int ExamsId { get; set; }
        
        [Display(Name = "Question")]
        public string Question { get; set; }
       
        [Display(Name = "Answer")]
        public int Answer { get; set; }

        
        [Display(Name = "Option 1")]
        public string Option1 { get; set; }

        [Required]
        [Display(Name = "Option 2")]
        public string Option2 { get; set; }

        [Required]
        [Display(Name = "Option 3")]
        public string Option3 { get; set; }

        [Required]
        [Display(Name = "Option 4")]
        public string Option4 { get; set; }

        public List<QuestionAnswerViewModel> QuestionAnswerList { get; set; }
        public IEnumerable<CExamPaperViewModel> ExamList { get; set; }
        public int TotalCount { get; set; }
        public int SelectedAnswer { get; set; }

        //public QuestionAnswerViewModel(QuestionAnswers questionAnswers)
        //{
        //    Id = questionAnswers.Id;
        //    ExamsId = questionAnswers.ExamsId;
        //    Question = questionAnswers.Question ?? "";
        //    Option1 = questionAnswers.Option1 ?? "";
        //    Option2 = questionAnswers.Option2 ?? "";
        //    Option3 = questionAnswers.Option3 ?? "";
        //    Option4 = questionAnswers.Option4 ?? "";
        //    Answer = questionAnswers.Answer;
        //}

        //public QuestionAnswers ConvertViewModel(QuestionAnswerViewModel qnAsViewModel)
        //{
        //    return new QuestionAnswers
        //    {
        //        Id = qnAsViewModel.Id,
        //        ExamsId = qnAsViewModel.ExamsId,
        //        Question = qnAsViewModel.Question ?? "",
        //        Option1 = qnAsViewModel.Option1 ?? "",
        //        Option2 = qnAsViewModel.Option2 ?? "",
        //        Option3 = qnAsViewModel.Option3 ?? "",
        //        Option4 = qnAsViewModel.Option4 ?? "",
        //        Answer = qnAsViewModel.Answer
        //    };
        //}
    }
}
