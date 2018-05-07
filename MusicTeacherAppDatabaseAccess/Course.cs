using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTeacherAppDatabaseAccess
{
    class Course
    {
        public string CourseId { set; get; }
        public string CourseName { set; get; }
        public string Section { set; get; }
        public string TeacherLastName { set; get; }


        public Course(string courseId, string courseName, string section, string teacherLastName)
        {
            CourseId = courseId;
            CourseName = courseName;
            Section = section;
            TeacherLastName = teacherLastName;
        }

        public Course(List<string> list)
        {
            CourseId = list[0];
            CourseName = list[1];
            Section = list[2];
            TeacherLastName = list[3];
        }


        public static List<string> GetCourseRowData(String courseId)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM MusicTeacherApp.dbo.Courses WHERE CourseId = @courseId", conn);

                command.Parameters.Add(new SqlParameter("courseId", courseId));

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


        public static void InsertCourseData(Course course)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                Course newEntry = course;

                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO MusicTeacherApp.dbo.Courses (CourseId, CourseName, Section, TeacherLastName) VALUES (@0, @1, @2, @3)", conn);


                insertCommand.Parameters.Add(new SqlParameter("0", newEntry.CourseId));
                insertCommand.Parameters.Add(new SqlParameter("1", newEntry.CourseName));
                insertCommand.Parameters.Add(new SqlParameter("2", newEntry.Section));
                insertCommand.Parameters.Add(new SqlParameter("3", newEntry.TeacherLastName));
                


                //Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                //Console.WriteLine("Done! Press enter to move to the next step");
                //Console.ReadLine();

            }
        }

        public static List<string> GetTeacherCourseList(String personId)   
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT CourseName FROM MusicTeacherApp.dbo.Courses c, MusicTeacherApp.dbo.Persons p WHERE p.PersonId = @personId AND c.TeacherLastName = p.LastName", conn);

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


        public static List<string> GetStudentCourseList(String personId)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT CourseName FROM MusicTeacherApp.dbo.PersonCourse WHERE PersonId = @personId", conn);

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


        public static List<string> GetCourseAssignmentList(String courseName)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT AssignmentName FROM MusicTeacherApp.dbo.Assignments WHERE CourseName = @courseName", conn);

                command.Parameters.Add(new SqlParameter("courseName", courseName));

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

        
        public static List<string> GetCourseStudentList(String courseName)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT PersonId FROM MusicTeacherApp.dbo.PersonCourse WHERE CourseName = @courseName", conn);

                command.Parameters.Add(new SqlParameter("courseName", courseName));

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



    }

}
