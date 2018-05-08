using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MusicTeacherAppDatabaseAccess;

namespace MusicTeacherGUI
{
    /// <summary>
    /// This class contains the global reference to the current user of the application so it can be accessed throughout the app
    /// </summary>
    public static class ConnectedUser
    {

        private static Person _p;

        /// <summary>
        /// Key: Course name, Value: List of assignments
        /// </summary>
        private static Dictionary<string, List<string>> _courses;

        /// <summary>
        /// Key: Course name, Value: List of students
        /// </summary>
        private static Dictionary<string, List<string>> _students;

        /// <summary>
        /// Preloads all the necessary information by accessing the database
        /// </summary>
        private static void preload()
        {

            _courses = new Dictionary<string, List<string>>();
            _students = new Dictionary<string, List<string>>();

            List<string> c;

            Console.WriteLine("Is teacher " + isTeacher());

            if (isTeacher())
            {
                // Get all the courses the teacher is in
                c = Course.GetTeacherCourseList(_p.PersonId);
            }
            else
            {
                // Get all the courses the student is in
                c = Course.GetStudentCourseList(_p.PersonId);

                Console.WriteLine(c);
            }



            // Add each course to our dictionary under the format of courseName, List of assignments
            if (c.Count > 0)
            {
                for (int i = 0; i < c.Count; i++)
                {
                    string cname = c[i];
                    var list = Course.GetCourseAssignmentList(cname);

                    _courses.Add(cname.ToString(), list);
                }
            }

            // Add all students to our dictionary under the format of courseName, list of students
            if (c.Count > 0)
            {
                for (int i = 0; i < c.Count; i++)
                {
                    _students.Add(c[i].ToLower(), Course.GetCourseStudentList(c[i]));
                }
            }
        }

        /// <summary>
        /// Unloads all the stored information for the connected user
        /// </summary>
        private static void unload()
        {
            _courses = null;
            _students = null;
        }

        /// <summary>
        /// Sets the connected user (set null to reset)
        /// </summary>
        /// <param name="p">Person object</param>
        public static void setConnUser(Person p = null)
        {
            _p = p;

            Console.WriteLine("Setting connected user" + p.PersonId);

            if (p != null)
            {
                // Call the preload
                preload();
            }
            else
            {
                unload();
            }
        }

        /// <summary>
        /// Gets the current connected user
        /// </summary>
        /// <returns>Person object</returns>
        public static Person getConnUser()
        {
            return _p;
        }

        /// <summary>
        ///  Returns if the connected user is a teacher
        /// </summary>
        /// <returns></returns>
        public static bool isTeacher()
        {
            return _p.Role.ToLower() == "teacher";
        }

        /// <summary>
        /// Returns if the connected user is a student
        /// </summary>
        /// <returns></returns>
        public static bool isStudent()
        {
            return _p.Role.ToLower() == "student";
        }

        /// <summary>
        /// Returns the connected user's person id
        /// </summary>
        /// <returns></returns>
        public static string getID()
        {
            return _p.PersonId;
        }

        /// <summary>
        /// Returns a list of courses the connected user is in
        /// </summary>
        /// <returns>List with each course name as a value</returns>
        public static List<string> getCourses()
        {
            return _courses.Keys.ToList<string>();
        }

        /// <summary>
        /// Returns a list with all the students in the given course
        /// </summary>
        /// <param name="course">Course id</param>
        /// <returns>List with students</returns>
        public static List<string> getStudentsFromCourse(string course)
        {
            course = course.ToLower();

            return _students.FirstOrDefault(x => x.Key.ToLower() == course).Value;
        }

        /// <summary>
        /// Returns a list of assignments for the given course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public static List<string> getAssignmentsFromCourse(string course)
        {
            course = course.ToLower();

            return _courses.FirstOrDefault(x => x.Key.ToLower() == course).Value;
        }

        /// <summary>
        /// Returns a List of tuples containing all the assignments for the current user
        /// </summary>
        /// <returns>Index: Tuple(courseName, assignmentName)</returns>
        public static List<Tuple<string, string>> getAllAssignments()
        {

            // List with a tuple inside
            // Index: Tuple( course name, assignment name )
            List<Tuple<string, string>> allAssignments = new List<Tuple<string, string>>();

            // Create a tuple to store Index, 
            //Tuple<string, string> allAssignments = new Tuple<string, string>();

            // Gets all the course names 
            List<string> keys = _courses.Keys.ToList<string>();

            // Iterate through the courses
            for (int i = 0; i < _courses.Count; i++)
            {
                // Get the assignments list for the given course
                List<string> assignmentList = _courses[keys[i]];

                // Iterate through the assignments for the course
                for (int k = 0; k < assignmentList.Count; k++)
                {
                    // Get the specific assignment name
                    string specificAssignment = assignmentList[k];

                    // Create a tuple to store it
                    Tuple<string, string> entry = new Tuple<string, string>(keys[i], specificAssignment);

                    // Add 
                    allAssignments.Add(entry);
                }
            }

            return allAssignments;
        }
    }
}
