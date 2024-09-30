using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePolls.Home_Page
{
    public partial class Home_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnShowQuestions(object sender, EventArgs e)
        {
            showQuestionType();
        }

        private void showQuestionType()
        {
            if (Switch_Question.Text == "Unanswered Questions")
            {
                Switch_Question.Text = "Answered Questions";
                Switch_Question.CssClass = "btn btn-success";
            }
            else if (Switch_Question.Text == "Answered Questions")
            {
                Switch_Question.Text = "Unanswered Questions";
                Switch_Question.CssClass = "btn btn-danger";

            }
        }
    }
}