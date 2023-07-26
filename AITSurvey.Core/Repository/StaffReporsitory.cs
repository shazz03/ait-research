using System;
using System.Data.SqlClient;


namespace AITSurvey.Core.Repository
{
    public class StaffReporsitory
    {
        // This method takes in a username and password and attempts to login the user
        public int Login(string userName, string password)
        {
            // Create a new SqlConnection object with the connection string from the Core.Database.Connection property
            using (var conn = new SqlConnection(Core.Database.Connection.ConnectionString))
            {
                // Create a parameterized SqlCommand object to prevent SQL injection attacks
                var cmd = new SqlCommand("SELECT Id FROM Staff WHERE Username=@username AND Password=@password", conn);

                // Add parameters to the SqlCommand object to avoid SQL injection attacks
                cmd.Parameters.AddWithValue("@username", userName);
                cmd.Parameters.AddWithValue("@password", password);

                // Open the connection to the database
                conn.Open();

                // Execute the query using ExecuteScalar
                var staffId = (int?)cmd.ExecuteScalar();

                // Close the database connection
                conn.Close();

                // If staffId is null, the user was not found, so throw a 404 exception
                if (!staffId.HasValue)
                {
                    throw new Exception("User not found");
                }

                // Otherwise, return the staffId
                return staffId.Value;
            }
        }
    }
}
