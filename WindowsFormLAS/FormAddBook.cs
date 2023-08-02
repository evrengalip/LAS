using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormLAS.Modell;

namespace WindowsFormLAS
{
    public partial class FormAddBook : Form
    {
        public FormAddBook()
        {
            InitializeComponent();
        }

        int BookId = 0;

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormAddBook_Load(object sender, EventArgs e)
        {
            comboBoxFill();
            BooksLoad();
        }

        void comboBoxFill()
        {//comboboxlara seçenekleri ekiyorum
            foreach (DataRow row in IDataBasee.DataToDataTable("select * from cupboards").Rows)
                cbbCupboard.Items.Add(row["name"].ToString());//name satırını ekliyorum

            foreach (DataRow row in IDataBasee.DataToDataTable("select * from types").Rows)
                cbbType.Items.Add(row["name"].ToString());//name satırını ekliyorum

            foreach (DataRow row in IDataBasee.DataToDataTable("select * from publishers").Rows)
                cbbPublisher.Items.Add(row["name"].ToString());//name satırını ekliyorum

            foreach (DataRow row in IDataBasee.DataToDataTable("select * from authors").Rows)
                cbbAuthorName.Items.Add(row["name"].ToString());//name satırını ekliyorum


        }

        void BooksLoad()
        {
            dg.DataSource = IDataBasee.DataToDataTable(
                "select * from books where active= 1 and authorName+' '+bookName like @search",
                new SqlParameter("@search", SqlDbType.VarChar) { Value= string.Format("%{0}%",txtFilter.Text)});
            //sağdaki data gried viewa kitabı aktardık(authorla book name kolonlarını birleştirdik,like search diyip searche filterda girilecek olan değeri atadık yani girilen değer aratılıcak)
            dg.Columns["id"].Visible=false;///id sütununu gizliyor
        }

        void AddBook()
        {
            List<SqlParameter>parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@registrationNumber",SqlDbType.Int) { Value= txtRegistrationNumber.Text });
            parameters.Add(new SqlParameter("@bookName",SqlDbType.VarChar) { Value = txtBookName.Text });
            parameters.Add(new SqlParameter("@authorName",SqlDbType.VarChar) { Value = cbbAuthorName.Text });
            parameters.Add(new SqlParameter("@publisher",SqlDbType.VarChar) { Value = cbbPublisher.Text });
            parameters.Add(new SqlParameter("@publicationYear",SqlDbType.VarChar) { Value = txtPublicationYear.Text });
            parameters.Add(new SqlParameter("@bookPage",SqlDbType.VarChar) { Value = txtPageNumber.Text });
            parameters.Add(new SqlParameter("@type",SqlDbType.VarChar) { Value = cbbType.Text });
            parameters.Add(new SqlParameter("@description",SqlDbType.VarChar) { Value = txtDescription.Text });
            parameters.Add(new SqlParameter("@cupboard",SqlDbType.VarChar) { Value = cbbCupboard.Text });
            parameters.Add(new SqlParameter("@shelf",SqlDbType.VarChar) { Value = txtShelf.Text });
            parameters.Add(new SqlParameter("@row",SqlDbType.VarChar) { Value = txtRow.Text });

            IDataBasee.ExecuteNonQuery("insert into books (registrationNumber,bookName,authorName,publisher,publicationYear,bookPage,type,description,cupboard,shelf,row) values (@registrationNumber,@bookName,@authorName,@publisher,@publicationYear,@bookPage,@type,@description,@cupboard,@shelf,@row)", parameters);

            BooksLoad();

            MessageBox.Show("Book addition successful");

        }

        void UpdateBook()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            //registartionnumaber(kayıtno)güncellenemez çünkü sadece bir kere girilmesi gerekir o yüzden yazmadım
            parameters.Add(new SqlParameter("@bookName", SqlDbType.VarChar) { Value = txtBookName.Text });
            parameters.Add(new SqlParameter("@authorName", SqlDbType.VarChar) { Value = cbbAuthorName.Text });
            parameters.Add(new SqlParameter("@publisher", SqlDbType.VarChar) { Value = cbbPublisher.Text });
            parameters.Add(new SqlParameter("@publicationYear", SqlDbType.VarChar) { Value = txtPublicationYear.Text });
            parameters.Add(new SqlParameter("@bookPage", SqlDbType.VarChar) { Value = txtPageNumber.Text });
            parameters.Add(new SqlParameter("@type", SqlDbType.VarChar) { Value = cbbType.Text });
            parameters.Add(new SqlParameter("@description", SqlDbType.VarChar) { Value = txtDescription.Text });
            parameters.Add(new SqlParameter("@cupboard", SqlDbType.VarChar) { Value = cbbCupboard.Text });
            parameters.Add(new SqlParameter("@shelf", SqlDbType.VarChar) { Value = txtShelf.Text });
            parameters.Add(new SqlParameter("@row", SqlDbType.VarChar) { Value = txtRow.Text });
            parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = BookId });

            IDataBasee.ExecuteNonQuery("update books set bookName=@bookName,authorName=@authorName,publisher=@publisher,publicationYear=@publicationYear,bookPage=@bookPage,type=@type,description=@description,cupboard=@cupboard,shelf=@shelf,row=@row where id=@id", parameters);

            BooksLoad();
            MessageBox.Show(" Update book addition successful");
        }

        void DeleteBook()
        {
          


            IDataBasee.ExecuteNonQuery("update books set active=0 where id=@id",new SqlParameter("@id", SqlDbType.Int) { Value=BookId});//active 0 olursa kullanıcı sillinmiş görür ama veritabanından silinmez veritabanında active 0 olmuş şekilde gözükür
            BooksLoad();
            MessageBox.Show(" Delete book addition successful");
        }

        void Clear()
        {
            BookId = 0;

            foreach (var item in tableLayoutPanel.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }

                if (item is ComboBox)
                {
                    ((ComboBox)item).Text = "";
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtBookName.Text)|| 
                string.IsNullOrEmpty(cbbAuthorName.Text)||
                string.IsNullOrEmpty(cbbType.Text))//eğer bunlar boş bırakılıp kaydetmeye çalışılırsa diye
            {
                MessageBox.Show("Book Title, Author Name and Book Type fields cannot be blank");
                return;
            }
            if (BookId > 0)
            {
                UpdateBook();
                Clear();
            }
            else
            {
                AddBook();
            }
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                BookId = Convert.ToInt32(dg.Rows[e.RowIndex].Cells["id"].Value);
                foreach (DataRow row in IDataBasee.DataToDataTable("select * from books where active=1 and id=@id", new SqlParameter("@id" , SqlDbType.Int) { Value = BookId }).Rows)//satırları okuması için Rows dedik
                {
                    txtRegistrationNumber.Text = row["registrationNumber"].ToString();
                    txtBookName.Text = row["bookName"].ToString();
                    cbbAuthorName.Text= row["authorName"].ToString();
                    txtPublicationYear.Text= row["publicationYear"].ToString();
                    txtPageNumber.Text = row["bookPage"].ToString() ;
                    cbbType.Text= row["type"].ToString();
                    txtDescription.Text = row["description"].ToString();
                    cbbCupboard.Text= row["cupboard"].ToString();
                    txtShelf.Text = row["shelf"].ToString();
                    txtRow.Text= row["row"].ToString();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (BookId > 0)//yani bir kitap seçilmişse
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to delete the selected book?", "Delete Book", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    DeleteBook();
                }
                else
                {
                    MessageBox.Show("transaction canceled");
                }
            }
            else
            {
                MessageBox.Show("select book");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            BooksLoad();//filtrele textboxunun texti her değiştiğinde metod akitf hale geliyor yani metot tetikleniyor
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
