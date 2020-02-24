using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UniversityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int PADLEFT = 65; 
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{"University App",PADLEFT}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            string connectionString = "Data Source=LAPTOP-J5RU88CT;Initial Catalog=UniversityDatabase;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            List<string> emails = new List<string>();
            List<string> passwords = new List<string>();
            try
            {
                sqlConnection.Open();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Connection Successful....");

                SqlCommand query = new SqlCommand("SELECT * FROM Users",sqlConnection);
                SqlDataReader reader = query.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nType your email :");
                String email = Console.ReadLine();
                Console.Write("Type your password :");
                String password = Console.ReadLine();
                while (reader.Read())
                {
                    emails.Add(reader[1].ToString());
                    passwords.Add(reader[2].ToString());
                }

                while (!emails.Contains(email) || !passwords.Contains(password) || !(emails.IndexOf(email) == passwords.IndexOf(password)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Provide correct details and try again");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\nType your email :");
                     email = Console.ReadLine();
                    Console.Write("Type your password :");
                     password = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hello! You've successfully signed in....");
            }
            catch (SqlException sqlEx)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(sqlEx);
            }
            finally
            {
                sqlConnection.Close();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
