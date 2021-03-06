﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTeacherAppDatabaseAccess
{
    public class Submission
    {
        public String SubmissionId { get; set; }
        public String PersonId { get; set; }
        public String CourseName { set; get; }
        public String AssignmentName { set; get; }
        public String FileLocation { set; get; }
        public DateTime SubmissionDateTime { set; get; }

        public Submission(String submissionId, String personId, String className, String assignmentName, String fileLocation, DateTime submissionDateTime)
        {
            SubmissionId = submissionId;
            PersonId = personId;
            CourseName = className;
            AssignmentName = assignmentName;
            FileLocation = fileLocation;
            SubmissionDateTime = submissionDateTime;
        }

        public Submission(List<string> list)
        {
            // No empty lists here
            if (list.Count < 1)
            {
                return;
            }

            SubmissionId = list[0];
            PersonId = list[1];
            CourseName = list[2];
            AssignmentName = list[3];
            FileLocation = list[4];
            SubmissionDateTime = Convert.ToDateTime(list[5]);
        }

        /// <summary>
        /// Gets all submission data for the given submission id
        /// </summary>
        /// <param name="submissionId"></param>
        /// <returns></returns>
        public static List<string> GetSubmissionRowData(String submissionId)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM MusicTeacherApp.dbo.Submissions WHERE SubmissionId = @submissionId", conn);
                
                command.Parameters.Add(new SqlParameter("submissionId", submissionId));

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
        /// Inserts a Submission object into the database
        /// </summary>
        /// <param name="submission"></param>
        public static void InsertSubmissionData(Submission submission)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Submission newEntry = submission;

                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO MusicTeacherApp.dbo.Submissions (SubmissionId, PersonId, ClassName, AssignmentName, FileLocation, SubmissionDateTime) VALUES (@0, @1, @2, @3, @4, @5)", conn);

                
                insertCommand.Parameters.Add(new SqlParameter("0", newEntry.SubmissionId));
                insertCommand.Parameters.Add(new SqlParameter("1", newEntry.PersonId));
                insertCommand.Parameters.Add(new SqlParameter("2", newEntry.CourseName));
                insertCommand.Parameters.Add(new SqlParameter("3", newEntry.AssignmentName));
                insertCommand.Parameters.Add(new SqlParameter("4", newEntry.FileLocation));
                insertCommand.Parameters.Add(new SqlParameter("5", newEntry.SubmissionDateTime));

                Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                //Console.WriteLine("Done! Press enter to move to the next step");
                //Console.ReadLine();ic

            }
        }

        public static List<string> GetSubmissionInfoForStudent(String assignmentName, string studentID)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM MusicTeacherApp.dbo.Submissions WHERE AssignmentName = @assignmentName AND PersonId = @studentId", conn);

                command.Parameters.Add(new SqlParameter("assignmentName", assignmentName));
                command.Parameters.Add(new SqlParameter("studentId", studentID));

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
        /// Counts all the current submissions and returns that number
        /// </summary>
        /// <returns>Number of rows in the submissions table</returns>
        public static int GetTotalSubmissions()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM MusicTeacherApp.dbo.Submissions", conn);

                int count = (int)cmd.ExecuteScalar();

                return count;
            }
        }
    }

}
