using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePolls.Leaderboard
{
    public partial class Leaderboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(AppSettings.ANSWERED_CONSTRAINT, AppSettings.ORDER_BY_ANSWERED_QUESTIONS);
            }
        }

        private void BindGrid(string ColumnOrder = "AnsweredQuestions", string OrderValue = "DESC")
        {
            string connString = ConfigurationManager.ConnectionStrings["EmployeePolls"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT Author, AnsweredQuestions, CreatedQuestions, AvatarURL " +
                                "FROM (SELECT VotedOption, SUM(VoteCount) AS AnsweredQuestions " +
                                      "FROM (SELECT VotedOptionOne AS VotedOption, COUNT(*) AS VoteCount " +
                                            "FROM Answers GROUP BY VotedOptionOne " +
                                            "UNION ALL " +
                                            "SELECT VotedOptionTwo AS VotedOption, COUNT(*) AS VoteCount " +
                                            "FROM Answers GROUP BY VotedOptionTwo) AS CombinedVotes GROUP BY VotedOption) AS T1 " +
                                      "INNER JOIN " +
                                      "(SELECT Users.UserId AS Author, COALESCE(COUNT(Questions.QuestionId), 0) AS CreatedQuestions, Users.AvatarURL FROM Users " +
                                      "LEFT JOIN Questions ON Questions.Author = Users.UserId " +
                                      "GROUP BY Users.UserId, Users.AvatarURL) AS T2 ON T1.VotedOption = T2.Author " +
                                "ORDER BY " + ColumnOrder + " " + OrderValue;

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void onChangeValueSort(object sender, EventArgs e)
        {
            int selectedValueIdx = sortControl.SelectedIndex;

            switch (selectedValueIdx)
            {
                case 1: // Sort By Author
                    AppSettings.Save(AppSettings.ORDER_BY_AUTHOR_ALPHABET_CONSTRAINT,
                                     AppSettings.ORDER_BY_AUTHOR_ALPHABET == "ASC" ? "DESC" : "ASC");
                    BindGrid(AppSettings.AUTHOR_CONSTRAINT, AppSettings.ORDER_BY_AUTHOR_ALPHABET);
                    break;
                case 2: // Sort By Answered Questions
                    AppSettings.Save(AppSettings.ORDER_BY_ANSWERED_QUESTIONS_CONSTRAINT,
                                     AppSettings.ORDER_BY_ANSWERED_QUESTIONS == "ASC" ? "DESC" : "ASC");
                    BindGrid(AppSettings.ANSWERED_CONSTRAINT, AppSettings.ORDER_BY_ANSWERED_QUESTIONS);
                    break;
                case 3: // Sort By CreatedQuestions
                    AppSettings.Save(AppSettings.ORDER_BY_CREATED_QUESTIONS_CONSTRAINT,
                                     AppSettings.ORDER_BY_CREATED_QUESTIONS == "ASC" ? "DESC" : "ASC");
                    BindGrid(AppSettings.CREATED_CONSTRAINT, AppSettings.ORDER_BY_CREATED_QUESTIONS);
                    break;
            }

        }

    }
}