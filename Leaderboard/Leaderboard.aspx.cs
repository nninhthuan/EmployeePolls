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
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string connString = ConfigurationManager.ConnectionStrings["EmployeePolls"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT UserId, AnsweredQuestions, CreatedQuestions, AvatarURL " +
                                "FROM (SELECT VotedOption, SUM(VoteCount) AS AnsweredQuestions " +
                                      "FROM (SELECT VotedOptionOne AS VotedOption, COUNT(*) AS VoteCount " +
                                            "FROM Answers GROUP BY VotedOptionOne " +
                                            "UNION ALL " +
                                            "SELECT VotedOptionTwo AS VotedOption, COUNT(*) AS VoteCount " +
                                            "FROM Answers GROUP BY VotedOptionTwo) AS CombinedVotes GROUP BY VotedOption) AS T1 " +
                                      "INNER JOIN " +
                                      "(SELECT Users.UserId, COALESCE(COUNT(Questions.QuestionId), 0) AS CreatedQuestions, Users.AvatarURL FROM Users " +
                                      "LEFT JOIN Questions ON Questions.Author = Users.UserId " +
                                      "GROUP BY Users.UserId, Users.AvatarURL) AS T2 ON T1.VotedOption = T2.UserId " +
                                "ORDER BY AnsweredQuestions DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}