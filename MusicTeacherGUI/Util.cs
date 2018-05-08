using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace MusicTeacherGUI
{
    public static class Util
    {

        /// <summary>
        /// Fills a combo box with the values from a list
        /// </summary>
        /// <param name="comboBox">WinForms combo box</param>
        /// <param name="values">Keys are ignored, values become items in the box</param>
        public static void populateCombobox(ComboBox comboBox, List<string> values)
        {
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
        public static void populateListView(ListView lView, List<string> values)
        {
            int range = values.Count();

            for (int i = 0; i < range; i++)
            {
                lView.Items.Add(values[i]);
            }
        }
    }
}
