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
            var miFactoria = factory.Create((ComboBox.SelectedItem.ToString()));
            miFactoria.Add(student);


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtBoxStudentId.Text), txtBoxName.Text, txtBoxSurname.Text, DateTime.Parse(txtBoxBirthDate.Text));
            switch (ComboBox.SelectedItem)
            {
                case "txt":
                    TxtFile txtFileFactory = new TxtFile();
                    txtFileFactory.Remove(student);
                    break;
                case "json":
                    JsonFile jsonFileFactory = new JsonFile();
                    jsonFileFactory.Remove(student);
                    break;
                case "xml":
                    XmlFile xmlFileFactory = new XmlFile();
                    xmlFileFactory.Remove(student);
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
                    TxtFile txtFileFactory = new TxtFile();
                    txtFileFactory.Update(student);
                    break;
                case "json":
                    JsonFile jsonFileFactory = new JsonFile();
                    jsonFileFactory.Update(student);
                    break;
                case "xml":
                    XmlFile xmlFileFactory = new XmlFile();
                    xmlFileFactory.Update(student);
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
                    TxtFile txtFileFactory = new TxtFile();
                    MessageBox.Show(txtFileFactory.List());
                    break;
                case "json":
                    JsonFile jsonFileFactory = new JsonFile();
                    MessageBox.Show(jsonFileFactory.List());
                    break;
                case "xml":
                    XmlFile xmlFileFactory = new XmlFile();
                    MessageBox.Show(xmlFileFactory.List());
                    break;
                default:
                    break;
            }
        }
    }
}
