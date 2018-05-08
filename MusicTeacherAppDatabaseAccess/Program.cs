using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTeacherAppDatabaseAccess
{
    public class Program
    {
        static void Main(string[] args)
        {

            // INITIAL TEST CODE FOR GetStudentCourseList
            // access row from database 
            // append each field to a list
            String student = "studentjd1";
            List<string> studentCourseList = Course.GetStudentCourseList(student);

            // display list results in console
            studentCourseList.ForEach(Console.WriteLine);
            Console.ReadLine();



            // INITIAL TEST CODE FOR GetCourseAssignmentList
            // access row from database 
            // append each field to a list
            String courseName = "Guitar 1";
            List<string> courseAssignmentList = Course.GetCourseAssignmentList(courseName);

            // display list results in console
            courseAssignmentList.ForEach(Console.WriteLine);
            Console.ReadLine();



            // INITIAL TEST CODE FOR GetTeacherCourseList
            // access row from database 
            // append each field to a list
            /*String teacher = "teacherws1";
            List<string> teacherCourseList = Course.GetTeacherCourseList(teacher);

            // display list results in console
            teacherCourseList.ForEach(Console.WriteLine);
            Console.ReadLine();



            // INITIAL TEST CODE FOR GetCourseStudentList
            // access row from database 
            // append each field to a list
            courseName = "Jazz Band";
            List<string> courseStudentList = Course.GetCourseStudentList(courseName);

            // display list results in console
            courseStudentList.ForEach(Console.WriteLine);
            Console.ReadLine();



    */


            // INITIAL TEST CODE FOR InsertSubmissionData()

            // create Submission Object for testing
            //Submission testSubmission8 = new Submission("testSubmission8", "testStudent8", "testClass8", "testAssignment8", "testFileLocation8", DateTime.Now);

            // insert object data into database
            //Submission.InsertSubmissionData(testSubmission8);

            Console.WriteLine("Total subs: " + Submission.GetTotalSubmissions());

            Console.ReadLine();

            /*Submission test1 = new Submission("NatTest", "studentjd1", "Jazz Band", "test", "url", DateTime.Now);

            Console.WriteLine("Test");

            Submission.InsertSubmissionData(test1);

            List<string> result = Submission.GetSubmissionRowData("NatTest");

            // display list results in console
            result.ForEach(Console.WriteLine);
            Console.ReadLine();*/


            // INIIAL TEST CODE FOR GetSubmissionRow() 

            // access row from database with SubmissionId
            // append each field to a list
            /*String testId = "testSubmission8";
            List<string> result = Submission.GetSubmissionRowData(testId);

            // display list results in console
            result.ForEach(Console.WriteLine);
            Console.ReadLine();
            */

        }
    }
}
/*            
            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                // Trusted_Connection is used to denote the connection uses Windows Authentication
                conn.ConnectionString = "Data Source=(localdb)\\MTADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                conn.Open();
                // Create the command
                SqlCommand command = new SqlCommand("SELECT * FROM MusicTeacherApp.dbo.Submissions WHERE SubmissionId = @0", conn);
                // Add the parameters.
                command.Parameters.Add(new SqlParameter("0", "testSubmission5"));

                /* Get the rows and display on the screen! 
                 * This section of the code has the basic code
                 * that will display the content from the Database Table
                 * on the screen using an SqlDataReader. */

/*               using (SqlDataReader reader = command.ExecuteReader())
               {
                   Console.WriteLine("Submission Query Result:");
                   while (reader.Read())
                   {
                       Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t",
                           reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]));
                   }
               }
               Console.WriteLine("Data displayed! Now press enter to move to the next section!");
               Console.ReadLine();
               Console.Clear();

               /* Above code was used to display the data from the Database table!
                * This following section explains the key features to use 
                * to add the data to the table. This is an example of another
                * SQL Command (INSERT INTO), this will teach the usage of parameters and connection.*/

/*               Console.WriteLine("INSERT INTO command");

               // Create the command, to insert the data into the Table!
               // this is a simple INSERT INTO command!

               SqlCommand insertCommand = new SqlCommand("INSERT INTO MusicTeacherApp.dbo.Submissions (SubmissionId, StudentId, ClassId, AssignmentId, FileLocation, SubmissionDateTime) VALUES (@0, @1, @2, @3, @4, @5)", conn);

               // In the command, there are some parameters denoted by @, you can 
               // change their value on a condition, in my code they're hardcoded.

               insertCommand.Parameters.Add(new SqlParameter("0", "testSubmission6"));
               insertCommand.Parameters.Add(new SqlParameter("1", "testStudent6"));
               insertCommand.Parameters.Add(new SqlParameter("2", "testClass6"));
               insertCommand.Parameters.Add(new SqlParameter("3", "testAssignment6"));
               insertCommand.Parameters.Add(new SqlParameter("4", "testFileLocation6"));
               insertCommand.Parameters.Add(new SqlParameter("5", DateTime.Now));

               // Execute the command, and print the values of the columns affected through
               // the command executed.

               Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
               Console.WriteLine("Done! Press enter to move to the next step");
               Console.ReadLine();
               Console.Clear();

               /* In this section there is an example of the Exception case
                * Thrown by the SQL Server, that is provided by SqlException 
                * Using that class object, we can get the error thrown by SQL Server.
                * In my code, I am simply displaying the error! */
/*                Console.WriteLine("Now the error trial!");

                // try block
                try
                {
                    // Create the command to execute! With the wrong name of the table (Depends on your Database tables)
                    SqlCommand errorCommand = new SqlCommand("SELECT * FROM someErrorColumn", conn);
                    // Execute the command, here the error will pop up!
                    // But since we're catching the code block's errors, it will be displayed inside the console.
                    errorCommand.ExecuteNonQuery();
                }
                // catch block
                catch (SqlException er)
                {
                    // Since there is no such column as someErrorColumn (Depends on your Database tables)
                    // SQL Server will throw an error.
                    Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                }
            }
            // Final step, close the resources flush dispose them. ReadLine to prevent the console from closing.
            Console.ReadLine();
            
        }
    }
}
 */