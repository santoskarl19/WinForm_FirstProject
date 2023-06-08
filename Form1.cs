using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_FirstProject
{
    public partial class Form1 : Form
    {
        Student student;
        List<Student> students;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            students = new List<Student>();

            students.Add(new Student { studentID = 1, firstName = "Karl", lastName = "Santos", 
                address = "Newark", monthAdmitted = MonthOfAdmission.January, grade= 'A'});
            students.Add(new Student { studentID = 2, firstName = "Nick", lastName = "Miller", 
                address = "Los Angeles", monthAdmitted = MonthOfAdmission.August, grade= 'B'});
            students.Add(new Student { studentID = 3, firstName = "Barney", lastName = "Stinson", 
                address = "New York City", monthAdmitted = MonthOfAdmission.March, grade= 'C'});
            students.Add(new Student { studentID = 4, firstName = "Mike", lastName = "Ross", 
                address = "Boston", monthAdmitted = MonthOfAdmission.December, grade= 'A'});

            studentGrid.DataSource = students;
            combo_Admission.DataSource = Enum.GetValues(typeof(MonthOfAdmission));
        }

        // Add button functionality
        private void btnAdd_Click(object sender, EventArgs e)
        {
            student = new Student();

            // add user input to Struct properties
            student.studentID = Int32.Parse(txtStudentId.Text);
            student.firstName = txtFirstName.Text;
            student.lastName = txtLastName.Text;
            student.address = txtAddress.Text;
            student.grade = Char.Parse(txtGrade.Text);
            student.monthAdmitted = (MonthOfAdmission)combo_Admission.SelectedIndex;

            students.Add(student); // add object to list
            MessageBox.Show("Record Added!"); // display message 
            studentGrid.DataSource = null; // set datasource to null to reset
            studentGrid.DataSource = students; // set datasource to new list

            // after all above, these will clear the fields
            txtStudentId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtGrade.Clear();
            combo_Admission.SelectedIndex = -1;
        }

        // Delete button functionality
        private void btnDelete_Click(object sender, EventArgs e)
        {
            students.RemoveAt(studentGrid.CurrentRow.Index);
            MessageBox.Show("Record Deleted!"); // display message 
            studentGrid.DataSource = null; // set datasource to null to reset
            studentGrid.DataSource = students; // set datasource to new list
        }

        // validate input field for student id
        private void txtStudentId_Validating(object sender, CancelEventArgs e)
        {
            int num;

            if (!Int32.TryParse(txtStudentId.Text, out num))
            {
                MessageBox.Show("Please input a number!");
                e.Cancel = true;
                txtStudentId.Clear();
            }
        }

        // validate input field for student grade
        private void txtGrade_Validating(object sender, CancelEventArgs e)
        {
            char letter;

            if (!Char.TryParse(txtGrade.Text, out letter))
            {
                MessageBox.Show("Please input one character only!");
                e.Cancel= true;
                txtGrade.Clear();
            }
        }

        // exits application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
