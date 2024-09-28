using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePolls.Models
{
    public class Answer
    {
        [ScaffoldColumn(false)]
        public string AnswerId { get; set; }
        public string NumberOfOptionOne { get; set; }
        public bool IsSelectedOptionOne { get; set; }
        public string NumberOfOptionTwo { get; set; }
        public bool IsSelectedOptionTwo { get; set; }
        public virtual ICollection<UserAnswer> UserAnswer { get; set; }
    }
}