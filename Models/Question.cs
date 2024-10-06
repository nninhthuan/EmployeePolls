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
        public DateTime CreatedDate { get; set; }
        //Lesson Learn:
        //1.
        //With code first, in model we have any property, then it allow us create column for that property
        //If Code First generates table with column does not match with property im model. You dont need to insert data for this column

        //2. Only create between general table in case of column cannot create duplicate data (PRIMARY KEY column)
    }
}