using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTeacherAppDatabaseAccess
{
    public class Person
    {
        public String PersonId { set; get; }
        public String FirstName { set; get; }
        public String LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public String Role { set; get; }

        public Person(string personId, string firstName, string lastName, DateTime dateOfBirth, string role)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Role = role;
        }

        public Person(List<string> list)
        {
            PersonId = list[0];
            FirstName = list[1];
            LastName = list[2];
            DateOfBirth = Convert.ToDateTime(list[3]);
            Role = list[4];
        }

        /// <summary>
        /// Returns all info for a person matching the given person id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public static List<string> GetPersonRowData(String personId)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM MusicTeacherApp.dbo.Persons WHERE PersonId = @personId", conn);

                command.Parameters.Add(new SqlParameter("personId", personId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            result.Add(Convert.ToString(reader[i]));
                        }


                    }
                }
            }
            //Console.WriteLine(result);
            //Console.ReadLine();
            return result;
        }

        /// <summary>
        /// Inserts into the database a person object
        /// </summary>
        /// <param name="person"></param>
        public static void InsertPersonData(Person person)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Person newEntry = person;

                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO MusicTeacherApp.dbo.Persons (PersonId, FirstName, LastName, DateOfBirth, Role) VALUES (@0, @1, @2, @3, @4)", conn);


                insertCommand.Parameters.Add(new SqlParameter("0", newEntry.PersonId));
                insertCommand.Parameters.Add(new SqlParameter("1", newEntry.FirstName));
                insertCommand.Parameters.Add(new SqlParameter("2", newEntry.LastName));
                insertCommand.Parameters.Add(new SqlParameter("3", newEntry.DateOfBirth));
                insertCommand.Parameters.Add(new SqlParameter("4", newEntry.Role));
                

                //Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                //Console.WriteLine("Done! Press enter to move to the next step");
                //Console.ReadLine();

            }
        }

        public static string GetNameFromID( string personId )
        {
            var data = GetPersonRowData(personId);

            if (data.Count > 0)
            {
                Person p = new Person(data);

                return p.LastName + ", " + p.FirstName;
            }

            return null;
        }

        public static List<string> fromFirstNameLastNameFormat(string formatted)
        {
            string[] words = formatted.Split(',');

            string firstName = words[1].TrimStart();
            string lastName = words[0];

            if (firstName == null)
            {
                firstName = "null";
            }

            if (lastName == null)
            {
                lastName = "null";
            }

            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM MusicTeacherApp.dbo.Persons WHERE FirstName = @first AND LastName = @last", conn);

                command.Parameters.Add(new SqlParameter("first", firstName));
                command.Parameters.Add(new SqlParameter("last", lastName));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            result.Add(Convert.ToString(reader[i]));
                        }


                    }
                }
            }
            return result;

        }
    }
}
