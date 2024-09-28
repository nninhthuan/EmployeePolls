using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePolls.Models
{
    public class Question
    {
        [ScaffoldColumn(false)]
        public string QuestionId { get; set; }
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
        public string QuestionLabel { get; set; }
        public string AnswerId { get; set; }
        public virtual Answer Answers { get; set; }
        public virtual User User { get; set; }
    }
}