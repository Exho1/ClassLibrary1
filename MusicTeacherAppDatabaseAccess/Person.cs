using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTeacherAppDatabaseAccess
{
    class Person
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
    }
}
