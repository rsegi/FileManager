using FileManager.Business.Layer;
using FileManager.Common.Layer;
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
            FileManagerBll fileBll = new FileManagerBll();

            fileBll.Add(txtBoxStudentId.Text, txtBoxName.Text, txtBoxSurname.Text, txtBoxBirthDate.Text, ComboBox.SelectedItem.ToString());
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            FileManagerBll fileBll = new FileManagerBll();
            fileBll.Remove(txtBoxStudentId.Text, txtBoxName.Text, txtBoxSurname.Text, txtBoxBirthDate.Text, ComboBox.SelectedItem.ToString());
        }


        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            FileManagerBll fileBll = new FileManagerBll();
            fileBll.Update(txtBoxStudentId.Text, txtBoxName.Text, txtBoxSurname.Text, txtBoxBirthDate.Text, ComboBox.SelectedItem.ToString());
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            FileManagerBll fileBll = new FileManagerBll();
            var message = fileBll.GetAll(ComboBox.SelectedItem.ToString());
            MessageBox.Show(message);
        }
    }
}
