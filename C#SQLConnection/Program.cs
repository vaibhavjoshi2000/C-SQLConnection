using System;
using System.Data.SqlClient; //Install This Nuget Package


namespace Program
{
    class Program
    {

        static void Main(string[] args)
        {
            // Step 1: Define the SQL connection string
            string connectionString = "Data Source=LP-215096543\\SQLEXPRESS;Initial Catalog=Database27Nov;Integrated Security=True";

            // Step 2: Write the SQL query
            string query = "Select StudentID, FirstName, LastName, Age, Course from Student";

            // Step 3: Create a SQL connection object which establish a connection
            // between your C# application and the SQL Server database.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    //Open the connection
                    connection.Open();
                    Console.WriteLine("Connection to database Successfully. \n");

                    // Step 5: Create a command object which help  for sending a specific SQL query  from C# file
                    // to the connected database.
                    SqlCommand command = new SqlCommand(query, connection);

                    // Step 6: Execute the query and read data
                    SqlDataReader reader = command.ExecuteReader();
                    //executes the SQL query and retrieves the result as a stream of rows (like a table).


                    // Step 7: Display data from the table
                    Console.WriteLine("Student Data:");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("ID\tFirst Name\tLast Name\tAge\tCourse");

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["StudentId"]}\t{reader["FirstName"]}\t\t{reader["LastName"]}\t\t{reader["Age"]}\t{reader["Course"]})");
                    }

                    //Close the reader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An Error Occured: " + ex.Message);
                }// Connection is closed automatically because of 'using'
            }
        }
    }
}


//  The using statement ensures that the database connection is
//  automatically closed and cleaned up after it is used,
//  even if something goes wrong.
