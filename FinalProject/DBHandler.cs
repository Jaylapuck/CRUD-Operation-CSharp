using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class DBHandler
    {
        string ConnStr = ConfigurationManager.ConnectionStrings["ContactConn"].ConnectionString;

        public List<Person> ReadAllPersons()
        {
            List<Person> personList = new List<Person>();

            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                SqlCommand cm = new SqlCommand("select * from Person", conn);

                using (SqlDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Person person = new Person();

                        if (Int32.TryParse(reader["Id"].ToString(), out int id))
                        {
                            person.Id = id;
                        }

                        person.FirstName = reader["FirstName"].ToString();
                        person.LastName = reader["LastName"].ToString();
                        person.Email = reader["Email"].ToString();

                        if (Int32.TryParse(reader["Age"].ToString(), out int age))
                        {
                            person.Age = age;
                        }

                        person.Email = reader["Email"].ToString();

                        if (Int32.TryParse(reader["PhoneNumber"].ToString(), out int phoneNumber))
                        {
                            person.PhoneNumber = phoneNumber;
                        }

                        personList.Add(person);
                    }
                }
            }

            return personList;
        }
    }
}
