using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            if(!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            string connString = ConfigurationManager.ConnectionStrings["EmployeePolls"].ConnectionString;
            string query = "SELECT QuestionId,  VotedOptionOne, TextOptionOne, VotedOptionTwo, TextOptionTwo " +
                           "\n FROM Questions qu LEFT JOIN Answers ans ON qu.AnswerId = ans.AnswerId ";
            switch (Switch_Question.Text)
            {
                case AppSettings.ANSWERED_QUESTIONS_LABEL:
                    query += "\n WHERE VotedOptionOne LIKE '%sarahedo%' OR VotedOptionTwo LIKE '%sarahedo%'";
                    break;
                case AppSettings.UNANSWERED_QUESTIONS_LABEL:
                    query += "\n WHERE VotedOptionOne NOT LIKE '%sarahedo%' AND VotedOptionTwo NOT LIKE '%sarahedo%'";
                    break;
                default:
                    break;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                QuestionGridView.DataSource = dt;
                QuestionGridView.DataBind();
            }
        }

        protected void OnShowQuestions(object sender, EventArgs e)
        {
            ShowQuestionType();
            BindGrid();
        }

        private void ShowQuestionType()
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