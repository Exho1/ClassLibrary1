using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTeacherAppDatabaseAccess
{
    public class Assignment
    {
        public string AssignmentId { set; get; }
        public string AssignmentName { set; get; }
        public string CourseName { set; get; }
        public int TotalPoints { set; get; }
        public DateTime DueDate { set; get; }
        public DateTime AvailableDate { set; get; }
        public string Comments { set; get; }


        public Assignment(string assignmentId, string assignmentName, string courseName, int totalPoints, DateTime dueDate, DateTime availableDate, string comments)
        {
            AssignmentId = assignmentId;
            AssignmentName = assignmentName;
            CourseName = courseName;
            TotalPoints = totalPoints;
            DueDate = dueDate;
            AvailableDate = availableDate;
            Comments = comments;
        }


        public Assignment(List<string> list)
        {
            AssignmentId = list[0];
            AssignmentName = list[1];
            CourseName = list[2];
            TotalPoints = Convert.ToInt32(list[3]);
            DueDate = Convert.ToDateTime(list[4]);
            AvailableDate = Convert.ToDateTime(list[5]);
            Comments = list[6];
        }

        // TODO: Need a function to get an assignment id from an assignment name

        /// <summary>
        /// Returns the assignment info for the given assignment id
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        public static List<string> GetAssignmentRowData(String assignmentId)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM MusicTeacherApp.dbo.Assignments WHERE AssignmentId = @assignmentId", conn);

                command.Parameters.Add(new SqlParameter("assignmentId", assignmentId));

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
        /// Inserts into the database a given assignment object
        /// </summary>
        /// <param name="assignment"></param>
        public static void InsertAssignmentData(Assignment assignment)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Assignment newEntry = assignment;

                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO MusicTeacherApp.dbo.Assignments (AssignmentId, AssignmentName, CourseName, TotalPoints, DueDate, AvailableDate, Comments) VALUES (@0, @1, @2, @3, @4, @5, @6)", conn);


                insertCommand.Parameters.Add(new SqlParameter("0", newEntry.AssignmentId));
                insertCommand.Parameters.Add(new SqlParameter("1", newEntry.AssignmentName));
                insertCommand.Parameters.Add(new SqlParameter("2", newEntry.CourseName));
                insertCommand.Parameters.Add(new SqlParameter("3", newEntry.TotalPoints));
                insertCommand.Parameters.Add(new SqlParameter("4", newEntry.DueDate));
                insertCommand.Parameters.Add(new SqlParameter("5", newEntry.AvailableDate));
                insertCommand.Parameters.Add(new SqlParameter("6", newEntry.Comments));


                //Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                //Console.WriteLine("Done! Press enter to move to the next step");
                //Console.ReadLine();

            }
        }
    }
}
