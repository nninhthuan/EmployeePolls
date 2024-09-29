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
            if (Switch_Question.Checked)
            {
                Switch_Question.Text = "Unanswered Questions";
            }
            else
            {
                Switch_Question.Text = "Answered Questions";
            }
        }
    }
}