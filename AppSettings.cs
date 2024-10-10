using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeePolls
{
    public class AppSettings
    {
        public static string Read(String sParam = "", String sDefault = "")
        {
            String query = "SELECT * FROM [USERS]";
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=LAPTOP-M8NP93P6;Database=Employee_Polls;Integrated Security=True"))
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

                        }
                    }
                }
            } catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return "";
        }
    }
}