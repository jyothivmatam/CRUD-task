using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace studentCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source = MOBACK; Initial Catalog = studentCRUD; Integrated Security = True";

            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection established Successfully");

                //Insert => I
               
                Console.WriteLine("Name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Gender : ");
                string gender = Console.ReadLine();
                Console.WriteLine("Email : ");
                string email = Console.ReadLine();

                string insertQuery = "insert into Student_record(name,gender,email) values ('" + name + "','" + gender + "','" + email + "')";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Data inserted");

                // Retrieve => R

                string displayQuery = "select * from Student_record";
                SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                SqlDataReader dataReader = displayCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine("Id: - " + dataReader.GetValue(0).ToString());
                    Console.WriteLine("Name: - " + dataReader.GetValue(1).ToString());
                    Console.WriteLine("Gender: - " + dataReader.GetValue(2).ToString());

                    Console.WriteLine("Email: - " + dataReader.GetValue(3).ToString());
                }
                dataReader.Close();

                // Update => U
                int d_id;
                string d_name;
                Console.WriteLine("enter the id that you would like to update");
                d_id = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the name of the user to update");
                d_name = Console.ReadLine();

                string updateQuery = "UPDATE Student_record SET name = " + d_name + " WHERE id = " +d_id + "";
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                updateCommand.ExecuteNonQuery();
                Console.WriteLine("Data updated Successfully!");

                //Delete => D

                int u_id;
                Console.WriteLine("Enter the id of the Student_record thats is to be deleted");
                u_id = int.Parse(Console.ReadLine());
                string deleteQuery = "DELETE FROM Student_record WHERE id =" + u_id;
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                deleteCommand.ExecuteNonQuery();
                Console.WriteLine("Deleted Succesfully!");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        
    }
}
