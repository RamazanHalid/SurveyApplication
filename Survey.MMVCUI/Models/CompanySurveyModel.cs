using Survey.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.MMVCUI.Models
{
    public class CompanySurveyModel
    {
        public CompanySurvey SurveyInfo { get; set; }
        public List<string> TextQuestions { get; set; }
        public List<MultipleChooseQuestionWithOptions> MultipleChooseQuestions { get; set; }
    }

    public class MultipleChooseQuestionWithOptions
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
    }
}