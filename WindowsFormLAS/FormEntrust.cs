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
using WindowsFormLAS.Model;
using WinFormLAS.Modell;

namespace WindowsFormLAS
{
    public partial class FormEntrust : Form
    {
        public FormEntrust()
        {
            InitializeComponent();
        }

        int ReaderId=0;
        int BookId = 0;
        int PunishmentDollar = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormEntrust_Load(object sender, EventArgs e)
        {
            ReaderLoad();
            BooksLoad();
        }

        void getReaderProfile()
        {
            pictureBox1.ImageLocation = Helper.profilePath(0);
            lblNameSurname.Text ="";
            lblClass.Text = "";
            lblSchoolNumber.Text = "";
            lblDelayFee.Text = "";
           
            PunishmentDollar = 0;
            //önceki değerde kalmış ise her ihtimale karşı değerlerini sıfırladık

            foreach (DataRow row in IDataBasee.DataToDataTable("select * from readers where active=1 and id=@id",new SqlParameter("@id", SqlDbType.Int) { Value=ReaderId}).Rows)
            {
                pictureBox1.ImageLocation = Helper.profilePath(ReaderId);
                lblNameSurname.Text = row["name"].ToString() +" "+ row["surname"].ToString();
                lblClass.Text = row["class"].ToString();
                lblSchoolNumber.Text = row["schoolNumber"].ToString();
                lblDelayFee.Text = "YOK";

                PunishmentDollar = getDelayFee();

                if (PunishmentDollar > 0)
                {
                    lblDelayFee.Text = "Delay Fee=" + string.Format("{0:C}", PunishmentDollar); ;
                    lblDelayFee.BackColor = Color.Red;
                }
                else
                {
                    lblDelayFee.Text = "eligible";
                    lblDelayFee.BackColor = Color.Transparent;
                }

                BookId = getEntrustId();
                getBookProfile();
            }
             
        }

        void getBookProfile()
        {
            lblRegistrationNumber.Text = "";
            lblBookName.Text = "";
            lblAuthorName.Text = "";
            //önceki değerde kalmış ise her ihtimale karşı değerlerini sıfırladık

            foreach (DataRow row in IDataBasee.DataToDataTable("select * from books where active=1 and id=@id", new SqlParameter("@id", SqlDbType.Int) { Value = BookId }).Rows)
            {
                lblRegistrationNumber.Text = row["registrationNumber"].ToString();
                lblBookName.Text = row["bookName"].ToString();
                lblAuthorName.Text = row["authorName"].ToString();

              

                
            }

        }

        void ReaderLoad()
        {
            dgReaders.DataSource = IDataBasee.DataToDataTable(
                "select * from readers where active=1 and name+' '+surname like @search", 
                new SqlParameter("@search",SqlDbType.VarChar) { Value = string.Format("%{0}%", txtFilterReader.Text) });
        }

        void BooksLoad()
        {
            dgBooks.DataSource = IDataBasee.DataToDataTable(
                "select * from books where active=1 and situation=1 and bookName like @search",
                new SqlParameter("@search", SqlDbType.VarChar) { Value = string.Format("%{0}%", txtFilterBooks.Text) });
        }
        
        void Entrust()
        {
            if (BookId==0||ReaderId==0)//kitap veya okuyucu seçilmediyse
            {
                MessageBox.Show("you didn't choose a book or a reader");
                return;
            }
            if (getEntrustId()>0)//okuyucunun emanet alıp da getirmediği bir kitap varsa
            {
                MessageBox.Show("Reader have a entrustment");
                return;
            }

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@bookId", SqlDbType.Int) { Value = BookId });
            parameters.Add(new SqlParameter("@readerId", SqlDbType.Int) { Value = ReaderId });
            parameters.Add(new SqlParameter("@dateEntrustment", SqlDbType.Date) { Value = DateTime.Now });//şuanki zamanı set ediyoruz emanet veriliş tarihine
            parameters.Add(new SqlParameter("@escrowRedemptionDate", SqlDbType.Date) { Value = DateTime.Now.AddDays(30) });//tarihe 30 gün ekledik çünkü 30 gün sonra getirmesi gerek

            IDataBasee.ExecuteNonQuery(
             "update books set situation=0 where id=@bookId " +//durumu 0 yapıyoruz çünkü kıtabı emanet ettiğimiz için kitap artık elimizde yok
             "insert into entrustment (bookId,readerId,dateEntrustment,escrowRedemptionDate) values (@bookId,@readerId,@dateEntrustment,@escrowRedemptionDate)", parameters);

            BooksLoad();//emanet ettikten sonra listeyi yenilemesi için
        }

        int getEntrustId()
        {
            foreach (DataRow row in IDataBasee.DataToDataTable(
                "select * from entrustment where readerId=@id and situation=0 and active=1", //okuyucunun emanet etmediği bir kitap varsa
                new SqlParameter("@id", SqlDbType.Int) { Value = ReaderId }).Rows)
            {
                return Convert.ToInt32(row["bookId"]);
            }
            return 0;
        }

        void ExtendTime()
        {
            if (BookId == 0 || ReaderId == 0)//kitap veya okuyucu seçilmediyse
            {
                MessageBox.Show("selected reader has no escrow");
                return;
            }
            if (getEntrustId() == 0)//okuyucunun emaneti yoksa
            {
                MessageBox.Show("Reader have a entrustment");
                return;
            }

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@bookId", SqlDbType.Int) { Value = BookId });
            parameters.Add(new SqlParameter("@dateEntrustment", SqlDbType.Date) { Value = DateTime.Now });//şuanki zamanı set ediyoruz emanet veriliş tarihine
            parameters.Add(new SqlParameter("@escrowRedemptionDate", SqlDbType.Date) { Value = DateTime.Now.AddDays(30) });//tarihe 30 gün ekledik çünkü 30 gün sonra getirmesi gerek

            IDataBasee.ExecuteNonQuery("update entrustment set dateEntrust=@dateEntrust,escrowRedemptionDate=@escrowRedemptionDate where bookId=@bookId", parameters);

            getReaderProfile();//emanet ettikten sonra okuyucuun listesini yenilemesi için
            ReaderLoad();//süreyi uzattığımızda artık solda kullanıcıda gecikme bedli yazmasın diye
        }

        void Deliver()
        {

            if (BookId == 0 || ReaderId == 0)//kitap veya okuyucu seçilmediyse
            {
                MessageBox.Show("selected reader has no escrow");
                return;
            }
            if (getEntrustId() == 0)//okuyucunun emaneti yoksa
            {
                MessageBox.Show("Reader have a entrustment");
                return;
            }

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@bookId", SqlDbType.Int) { Value = BookId });
            parameters.Add(new SqlParameter("@escrowTransactionDate", SqlDbType.Date) { Value = DateTime.Now });
      

            IDataBasee.ExecuteNonQuery(
                "update books set situation=1 where id=@bookId " +
                "update entrustment set escrowTransactionDate=@escrowTransactionDate, situation=1 where bookId=@bookId", parameters);//eğer emanet teslim edilmişse,emanetler tablosundaki o id'ye denk gelen kitabın durum kısmını 1 ve kitaplar tablosundaki o id'ye denk gelen durum ksımını da 1 yaptık

            getReaderProfile();//emanet ettikten sonra okuyucuun listesini yenilemesi için
            ReaderLoad();//süreyi uzattığımızda artık solda kullanıcıda gecikme bedli yazmasın diye
            BooksLoad();
        }
        
        int getDelayFee()
        {
            int punishmentDollar = 1;
            int dayDifference = 0;
            foreach (DataRow row in IDataBasee.DataToDataTable(
               "select * from entrustment where readerId=@id and situation=0 and active=1", //okuyucunun emanet etmediği bir kitap varsa
               new SqlParameter("@id", SqlDbType.Int) { Value = ReaderId }).Rows)
            {
                TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(row["escrowRedemptionDate"]);//timespan sınıfı tarihler arasında işlem yapmaya yarar
                dayDifference = timeSpan.Days;


            }
            if (dayDifference > 0)
            {
                return (dayDifference * punishmentDollar);
            }
            return 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>-1)
            {
                ReaderId = Convert.ToInt32(dgReaders.Rows[e.RowIndex].Cells["id"].Value);
                getReaderProfile();
            }
        }

        private void txtFilterReader_TextChanged(object sender, EventArgs e)
        {
            ReaderLoad();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrust_Click(object sender, EventArgs e)
        {
            Entrust();
        }

        private void txtFilterReaders_TextChanged(object sender, EventArgs e)
        {
            BooksLoad();
        }

        private void dgBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
             
                if (ReaderId ==0)
                {
                    MessageBox.Show("Select a reader!");
                    return;
                }
                if (getEntrustId() > 0)//seçili okuyucunun emaneti varsa
                {
                    MessageBox.Show("The rader has a entrustment");
                    return;
                }
                BookId = Convert.ToInt32(dgBooks.Rows[e.RowIndex].Cells["id"].Value);
                getBookProfile();
            }
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (PunishmentDollar>0)
            {
                DialogResult dialogresult = MessageBox.Show(
                    "Has The reader's" + string.Format("{0:C}", PunishmentDollar)+ "been received?","Delay Fee",MessageBoxButtons.YesNo);
                if(dialogresult == DialogResult.Yes)
                {
                    ExtendTime();
                }
            }
            else
            {
                ExtendTime();
            }
        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {

            if (PunishmentDollar>0)
            {
                DialogResult dialogresult = MessageBox.Show(
                    "Has The reader's" + string.Format("{0:C}", PunishmentDollar) + " been received?", "Delay Fee", MessageBoxButtons.YesNo);
                if (dialogresult == DialogResult.Yes)
                {
                    Deliver();
                }
            }
            else
            {
                Deliver();
            }
        }
    }
}
