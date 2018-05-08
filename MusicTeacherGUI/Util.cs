using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using MusicTeacherAppDatabaseAccess;

namespace MusicTeacherGUI
{
    public static class Util
    {

        /// <summary>
        /// Fills a combo box with the values from a list
        /// </summary>
        /// <param name="comboBox">WinForms combo box</param>
        /// <param name="values">Keys are ignored, values become items in the box</param>
        public static void populateCombobox(ComboBox comboBox, List<string> values, bool keepContents = false)
        {

            if (!keepContents)
            {
                comboBox.Items.Clear();
            }

            int range = values.Count();

            for (int i = 0; i < range; i++)
            {
                comboBox.Items.Add(values[i]);
            }
        }

        /// <summary>
        /// Fills a list view with the values from a list
        /// </summary>
        /// <param name="comboBox">WinForms list view</param>
        /// <param name="values">Keys are ignored, values become items in the box</param>
        public static void populateListView(ListView lView, List<string> values, bool keepContents = false)
        {

            if (!keepContents)
            {
                lView.Items.Clear();
            }

            int range = values.Count();

            for (int i = 0; i < range; i++)
            {
                lView.Items.Add(values[i]);
            }
        }

        public static bool listItemContainsAssignment(string listItem, string classname, string assignmentname)
        {
            if (listItem.ToLower() == (classname + " - " + assignmentname).ToLower())
            {
                return true;
            }
            return false;
        }

        public static Assignment listItemContainsAnyAssignment(string haystack)
        {
            var all = ConnectedUser.getAllAssignments();

            for (int i = 0; i < all.Count; i++)
            {
                var tup = all[i];

                if (listItemContainsAssignment(haystack, tup.Item1, tup.Item2))
                {
                    List<string> contents = Assignment.GetAssignmentRowDataByName(tup.Item2);

                    Assignment a = new Assignment(contents);

                    return a;
                }
            }

            return null;
        }



    }
}
