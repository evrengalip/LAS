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
using WinFormLAS.Modell;

namespace WindowsFormLAS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        void DataGridViewLoad()
        {
            dgEntrustBooks.DataSource = IDataBasee.DataToDataTable("select registrationNumber as [Registraation Number],bookName as [Book Name],authorName as [Author Name],publisher as [Publisher],publicationYear as [Publication Year],bookPage as [Book Page],type as [Type] from books where active=1 and situation= 0");//kitap hala emanetse
            dgAvailableBooks.DataSource = IDataBasee.DataToDataTable("select registrationNumber as [Registraation Number],bookName as [Book Name],authorName as [Author Name],publisher as [Publisher],publicationYear as [Publication Year],bookPage as [Book Page],type as [Type] from books where active=1 and situation= 1");//kitap bizdeyse yani emanet değilse
            dgReaders.DataSource = IDataBasee.DataToDataTable("select name as [Name],surname as [Surname],gender as [Gender],class as [Class],schoolNumber as [School Number],phoneNumber as [Phone Number],adress as [Adress] from readers where active=1");

        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            //DataGridViewLoad(); bu load sadece form ilk açıldığında tetiklenir o yüzden en aşşağıdaki main activaeda bu metodu koyduk çünkü main activated form her göründüğünde tetiklenir
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

        private void btnEntrustOperation_Click(object sender, EventArgs e)
        {
            FormEntrust formentrust = new FormEntrust();
            formentrust.Show();
        }

        private void btnStatisticts_Click(object sender, EventArgs e)
        {
            FormStatistics formStatistics = new FormStatistics();
            formStatistics.Show();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            DataGridViewLoad();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
