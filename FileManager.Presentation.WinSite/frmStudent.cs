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
            string choice = "VuelingFile";

            var factory = FactoryProvider.getFactory(choice);
            var fileFactory = factory.Create((ComboBox.SelectedItem.ToString()));
            fileFactory.Add(student);


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtBoxStudentId.Text), txtBoxName.Text, txtBoxSurname.Text, DateTime.Parse(txtBoxBirthDate.Text));
            string choice = "VuelingFile";
            var factory = FactoryProvider.getFactory(choice);
            var fileFactory = factory.Create((ComboBox.SelectedItem.ToString()));
            fileFactory.Remove(student);
        }


        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtBoxStudentId.Text), txtBoxName.Text, txtBoxSurname.Text, DateTime.Parse(txtBoxBirthDate.Text));
            string choice = "VuelingFile";
            var factory = FactoryProvider.getFactory(choice);
            var fileFactory = factory.Create((ComboBox.SelectedItem.ToString()));
            fileFactory.Update(student);
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            string choice = "VuelingFile";
            var factory = FactoryProvider.getFactory(choice);
            var fileFactory = factory.Create((ComboBox.SelectedItem.ToString()));
            MessageBox.Show(fileFactory.List());
        }
    }
}
