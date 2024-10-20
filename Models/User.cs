﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace EmployeePolls.Models
{
    public class User
    {
        [ScaffoldColumn(false)]
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string AvatarURL { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}