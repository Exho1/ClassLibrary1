using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTeacherAppDatabaseAccess
{
    class Grade
    {
        public string GradeId { set; get; }
        public string AssignmentId { set; get; }
        public int Score { set; get; }
        public string PersonId { set; get; }
        public string IsGraded { set; get; }

        public Grade(string gradeId, string assignmentId, int score, string personId, string isGraded)
        {
            GradeId = gradeId;
            AssignmentId = assignmentId;
            Score = score;
            PersonId = personId;
            IsGraded = isGraded;
        }


        public Grade(List<string> list)
        {
            GradeId = list[0];
            AssignmentId = list[1];
            Score = Convert.ToInt32(list[2]);
            PersonId = list[3];
            IsGraded = list[4];
        }



        public static List<string> GetGradeRowData(String gradeId)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM MusicTeacherApp.dbo.Grades WHERE GradeId = @gradeId", conn);

                command.Parameters.Add(new SqlParameter("gradeId", gradeId));

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


        public static void InsertGradeData(Grade grade)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Grade newEntry = grade;

                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO MusicTeacherApp.dbo.Grades (GradeId, AssignmentId, Score, PersonId, IsGraded) VALUES (@0, @1, @2, @3, @4)", conn);


                insertCommand.Parameters.Add(new SqlParameter("0", newEntry.GradeId));
                insertCommand.Parameters.Add(new SqlParameter("1", newEntry.AssignmentId));
                insertCommand.Parameters.Add(new SqlParameter("2", newEntry.Score));
                insertCommand.Parameters.Add(new SqlParameter("3", newEntry.PersonId));
                insertCommand.Parameters.Add(new SqlParameter("4", newEntry.IsGraded));


                //Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                //Console.WriteLine("Done! Press enter to move to the next step");
                //Console.ReadLine();

            }
        }


        public static void UpdateScore(Grade grade)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Grade updateEntry = grade;
                string gradeId = grade.GradeId;

                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand updateCommand = new SqlCommand("UPDATE MusicTeacherApp.dbo.Grades SET Score = @0, IsGraded = @1 WHERE GradeId = @gradeId", conn);


                updateCommand.Parameters.Add(new SqlParameter("0", updateEntry.Score));
                updateCommand.Parameters.Add(new SqlParameter("1", updateEntry.IsGraded));

                updateCommand.Parameters.Add(new SqlParameter("gradeId", gradeId));



                //Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                //Console.WriteLine("Done! Press enter to move to the next step");
                //Console.ReadLine();

            }
        }
    }
}
