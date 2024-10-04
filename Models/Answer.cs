using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeePolls.Models
{
    public class Answer
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        public string VotedOptionOne { get; set; }
        public string TextOptionOne { get; set; }
        public string NumberOfOptionOne { get; set; }
        public string VotedOptionTwo { get; set; }
        public string TextOptionTwo { get; set; }
        public string NumberOfOptionTwo { get; set; }
        public virtual ICollection<UserAnswer> UserAnswer { get; set; } = new List<UserAnswer>();
    }
}