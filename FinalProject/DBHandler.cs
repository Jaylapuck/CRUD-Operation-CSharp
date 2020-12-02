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
                }
            }

            return personList;
        }
    }
}