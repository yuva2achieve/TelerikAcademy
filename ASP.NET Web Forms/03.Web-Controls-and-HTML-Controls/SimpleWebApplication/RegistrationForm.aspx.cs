using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleWebApplication
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterStudentButton.Click += RegisterStudentButton_Click;
        }

        protected void RegisterStudentButton_Click(object sender, EventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string facultyNumber = FacultyNumberTextBox.Text;
            string university = UniversityDropDown.SelectedValue;
            string specialty = SpecialtyDropDown.SelectedValue;
            int[] selectedItemsIndex = CoursesListBox.GetSelectedIndices();
            string courses = string.Empty;

            for (int i = 0; i < selectedItemsIndex.Length; i++)
            {
                courses += CoursesListBox.Items[selectedItemsIndex[i]] + "\n";
            }

            string registrationDetails = String.Format
                ("FirstName: {0}\nLastName: {1}\nFacultyNumber: {2}\nUniversity: {3}\nSpecialty: {4}\nCourses: {5}\n",
                firstName, lastName, facultyNumber, university, specialty, courses);

            FormSelectionContainer.Text = registrationDetails;
        }
    }
}