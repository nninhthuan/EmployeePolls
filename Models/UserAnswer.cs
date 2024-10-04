using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeePolls.Models
{
    public class UserAnswer
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAnswerId { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

    }
}