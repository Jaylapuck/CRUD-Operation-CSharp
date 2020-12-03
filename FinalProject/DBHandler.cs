using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class DBHandler
    {
        //private constructor
        private DBHandler()
        { }

        //private object instantiated with private contrsuctor
        private static readonly DBHandler instance = new DBHandler();

        //public static property to get the object
        public static DBHandler Instance
        {
            get { return instance; }
        }

        private string ConnString = ConfigurationManager.ConnectionStrings["ContactConn"].ConnectionString;

        public List<Person> ReadAllPersons()
        {
            List<Person> personList = new List<Person>();

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlCommand cm = new SqlCommand("select * from Person", conn);

                using (SqlDataReader sqlDataReader = cm.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Person person = new Person();

                        if (Int32.TryParse(sqlDataReader["Id"].ToString(), out int id))
                        {
                            person.Id = id;
                        }

                        person.FirstName = sqlDataReader["FirstName"].ToString();
                        person.LastName = sqlDataReader["LastName"].ToString();
                        person.Email = sqlDataReader["Email"].ToString();

                        if (Int32.TryParse(sqlDataReader["Age"].ToString(), out int age))
                        {
                            person.Age = age;
                        }

                        person.Email = sqlDataReader["Email"].ToString();

                        person.PhoneNumber = sqlDataReader["Phone_Number"].ToString();

                        personList.Add(person);
                    }
                    sqlDataReader.Close();
                }
            }

            return personList;
        }

        public void InsertingRecord(string FirstName, string LastName, int Age, string Email, string Phone)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                string query = "insert into Person (FirstName, LastName, Age, Email, Phone_Number) values(@FN,@LN,@A,@E,@PN)";
                SqlCommand cmd = new SqlCommand(query, conn, transaction);

                cmd.Parameters.AddWithValue("@FN", FirstName);
                cmd.Parameters.AddWithValue("@LN", LastName);
                cmd.Parameters.AddWithValue("@A", Age);
                cmd.Parameters.AddWithValue("@E", Email);
                cmd.Parameters.AddWithValue("@PN", Phone);

                cmd.ExecuteNonQuery();
                transaction.Commit();
            }

            //try
            //{
            //    conn.Open();
            //    var rowsAffected = cmd.ExecuteNonQuery();
            //    Console.WriteLine("Records Inserted Succesfully");
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine("Error Generated. Details: " + e.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }

        public void UpdateRecord(string FirstName, string LastName, int Age, string Email, string Phone, int ID)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("update Person set FirstName = @FN, LastName = @LN, Age = @A, @E = Email, Phone_Number = @PN where Id = @rID", conn, transaction);

                cmd.Parameters.AddWithValue("@FN", FirstName);
                cmd.Parameters.AddWithValue("@LN", LastName);
                cmd.Parameters.AddWithValue("@A", Age);
                cmd.Parameters.AddWithValue("@E", Email);
                cmd.Parameters.AddWithValue("@PN", Phone);
                cmd.Parameters.AddWithValue("@rID", ID);

                cmd.ExecuteNonQuery();
                transaction.Commit();

                //try
                //{
                //    conn.Open();
                //    var rowsAffected = cmd.ExecuteNonQuery();
                //    Console.WriteLine("Record Updated Succesfully");
                //}
                //catch (SqlException e)
                //{
                //    Console.WriteLine("Error Generated. Details: " + e.ToString());
                //}
                //finally
                //{
                //    conn.Close();
                //}
            }
        }

        public void DeleteRecord(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("delete from Person where Id = @rID", conn, transaction);

                cmd.Parameters.AddWithValue("@rID", id);

                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
        }
    }
}