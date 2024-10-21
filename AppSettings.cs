using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeePolls
{
    public class AppSettings
    {
        public const string AUTHOR_CONSTRAINT = "Author";
        public const string ANSWERED_CONSTRAINT = "AnsweredQuestions";
        public const string CREATED_CONSTRAINT = "CreatedQuestions";

        public const string ORDER_BY_AUTHOR_ALPHABET_CONSTRAINT = "ORDER_BY_AUTHOR_ALPHABET";
        public const string ORDER_BY_ANSWERED_QUESTIONS_CONSTRAINT = "ORDER_BY_ANSWERED_QUESTIONS";
        public const string ORDER_BY_CREATED_QUESTIONS_CONSTRAINT = "ORDER_BY_CREATED_QUESTIONS";

        public static string ORDER_BY_AUTHOR_ALPHABET = "";
        public static string ORDER_BY_ANSWERED_QUESTIONS = "";
        public static string ORDER_BY_CREATED_QUESTIONS = "";

        public static bool LoadData()
        {
            ORDER_BY_AUTHOR_ALPHABET = Read(ORDER_BY_AUTHOR_ALPHABET_CONSTRAINT);
            ORDER_BY_ANSWERED_QUESTIONS = Read(ORDER_BY_ANSWERED_QUESTIONS_CONSTRAINT);
            ORDER_BY_CREATED_QUESTIONS = Read(ORDER_BY_CREATED_QUESTIONS_CONSTRAINT);

            return true;
        }
        public static string Read(string sParam = "")
        {
            String query = "SELECT [PARAMETER_VALUE] FROM [SETTINGS] WHERE [PARAMETER_NAME] = '" + sParam + "'";
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["EmployeePolls"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return reader["PARAMETER_VALUE"].ToString();
                        }
                    }
                }
            } catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return "";
        }

        public static bool Save(string sParam = "", string sVal = "")
        {
            String query = "UPDATE [SETTINGS] SET [PARAMETER_VALUE] = '" + sVal + "' WHERE [PARAMETER_NAME] = '" + sParam + "'";
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["EmployeePolls"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteReader();
                    LoadData();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return false;
        }
    }
}