using FileManager.Common.Layer;
using FileManager.DataAccess.Data;
using System;
using System.Windows.Forms;

namespace FileManager.Presentation.WinSite
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            Student student = new Student(int.Parse(txtBoxStudentId.Text), txtBoxName.Text, txtBoxSurname.Text, DateTime.Parse(txtBoxBirthDate.Text));
            switch (ComboBox.SelectedItem)
            {
                case "txt":
                    TxtStudentDao txtFileFactory = new TxtStudentDao();
                    txtFileFactory.AddStudent(student);
                    break;
                case "json":
                    JsonStudentDao jsonFileFactory = new JsonStudentDao();
                    jsonFileFactory.AddStudent(student);
                    break;
                case "xml":
                    XmlStudentDao xmlFileFactory = new XmlStudentDao();
                    xmlFileFactory.AddStudent(student);
                    break;
                default:
                    break;
            }


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtBoxStudentId.Text), txtBoxName.Text, txtBoxSurname.Text, DateTime.Parse(txtBoxBirthDate.Text));
            switch (ComboBox.SelectedItem)
            {
                case "txt":
                    TxtStudentDao txtFileFactory = new TxtStudentDao();
                    txtFileFactory.RemoveStudent(student);
                    break;
                case "json":
                    JsonStudentDao jsonFileFactory = new JsonStudentDao();
                    jsonFileFactory.RemoveStudent(student);
                    break;
                case "xml":
                    XmlStudentDao xmlFileFactory = new XmlStudentDao();
                    xmlFileFactory.RemoveStudent(student);
                    break;
                default:
                    break;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtBoxStudentId.Text), txtBoxName.Text, txtBoxSurname.Text, DateTime.Parse(txtBoxBirthDate.Text));
            switch (ComboBox.SelectedItem)
            {
                case "txt":
                    TxtStudentDao txtFileFactory = new TxtStudentDao();
                    txtFileFactory.UpdateStudent(student);
                    break;
                case "json":
                    JsonStudentDao jsonFileFactory = new JsonStudentDao();
                    jsonFileFactory.UpdateStudent(student);
                    break;
                case "xml":
                    XmlStudentDao xmlFileFactory = new XmlStudentDao();
                    xmlFileFactory.UpdateStudent(student);
                    break;
                default:
                    break;
            }
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            switch (ComboBox.SelectedItem)
            {
                case "txt":
                    TxtStudentDao txtFileFactory = new TxtStudentDao();
                    MessageBox.Show(txtFileFactory.ListStudents());
                    break;
                case "json":
                    JsonStudentDao jsonFileFactory = new JsonStudentDao();
                    MessageBox.Show(jsonFileFactory.ListStudents());
                    break;
                case "xml":
                    XmlStudentDao xmlFileFactory = new XmlStudentDao();
                    MessageBox.Show(xmlFileFactory.ListStudents());
                    break;
                default:
                    break;
            }
        }
    }
}
