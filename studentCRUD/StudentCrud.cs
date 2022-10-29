using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace studentCRUD
{
     class StudentCrud
    {

        SqlConnection sqlConnection = new SqlConnection("Data Source = MOBACK; Initial Catalog = studentCRUD; Integrated Security = True");

        public void Create(string name,string gender,string email)
        {
            try
            {
                sqlConnection.Open();
                //Console.WriteLine("Enter Student Name:");
                //string name = Console.ReadLine();
                //Console.WriteLine("Enter Student gender:");
                //string gender = Console.ReadLine();
                //Console.WriteLine("Enter Student email:");
                //string email=Console.ReadLine();


                string createQuery = "exec spCreateStudentInformation1'" + name + "','" + gender + "','" + email+"'" ;
                SqlCommand createCommand = new SqlCommand(createQuery, sqlConnection);
                createCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void DisplayAll()
        {
            try
            {
                sqlConnection.Open();

                string retrieveAllQuery = "exec spAllStudentsDisplay";
                SqlCommand retrieveAllCommand = new SqlCommand(retrieveAllQuery, sqlConnection);
                SqlDataReader dataReader = retrieveAllCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.Write("\nStudent Id:" + dataReader.GetValue(0));
                    Console.Write("\tStudent Name:" + dataReader.GetString(1));
                    Console.Write("\tStudent gender:" + dataReader.GetString(2));
                    Console.Write("\tStudent email:" + dataReader.GetValue(3));
                }
                dataReader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Display()
        {
            try
            {
                sqlConnection.Open();
                Console.WriteLine("\nEnter the Student Id you want to display");
                int EmpID = Convert.ToInt32(Console.ReadLine());

                string retrieveQuery = "exec  spOneStudentDisplay " + EmpID;
                SqlCommand retrieveCommand = new SqlCommand(retrieveQuery, sqlConnection);
                SqlDataReader dataReader = retrieveCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.Write("\nStudent ID:" + dataReader.GetValue(0));
                    Console.Write("\tName:" + dataReader.GetString(1));
                    Console.Write("\tage:" + dataReader.GetValue(2));
                    Console.Write("\temail:" + dataReader.GetValue(3));
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Update(int Id,string name,string gender,string email)
        {
            try
            {
                sqlConnection.Open();
                //Console.WriteLine("Enter StudentId ID that you want to update:");
                //int stuId = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Re-Name Student Name:");
                //string Sname = Console.ReadLine();
                //Console.WriteLine("Enter Student gender:");
                //string gender =Console.ReadLine();
                //Console.WriteLine("Enter Student email that you want to modify:");
                //string email=Console.ReadLine();
                
                

                string updateQuery = "exec spUpdateStudent " + Id + ",'" + name + "','" + gender + "','" + email + "'";
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Delete(int Id)
        {
            try
            {
                sqlConnection.Open();
                //Console.WriteLine("Enter Student ID that you want to delete:");
                //int EmpID = Convert.ToInt32(Console.ReadLine());

                string deleteQuery = "exec spDeleteStudent'" + Id + "'";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                deleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
    

