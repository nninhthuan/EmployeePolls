using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePolls.Models
{
    public class UserAnswer
    {
        [ScaffoldColumn(false)]
        [Key]
        public string UserAnswerId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public string AnswerId { get; set; }
        public Answer Answer { get; set; }

    }
}