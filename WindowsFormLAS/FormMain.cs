using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormLAS.Model;

namespace WindowsFormLAS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // MessageBox.Show(UserInfo.userId.ToString());
            // to string metodu sayisal veya baska bir sekilde alinan veriyi string turune cevirmek veya string gibi gostermek icin kullanilir.
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            FormAddBook frm = new FormAddBook();
            frm.Show();
        }

        private void btnAddReader_Click(object sender, EventArgs e)
        {
            FormAddReader formAddReader = new FormAddReader();
            formAddReader.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit();
            formEdit.Show();
        }
    }
}
