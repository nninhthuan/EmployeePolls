using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int AnswerId { get; set; }
        public virtual Answer Answers { get; set; }
        public virtual User User { get; set; }
    }
}