using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormLAS.Modell;

namespace WindowsFormLAS
{
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
           
        }

        void LookStatistics()
        {
            string query = "";

            switch (cbbStatistics.SelectedIndex)
            {
                case 0:
                    query = "select name+' '+surname as X,COUNT(*) as Y from entrustment inner join readers on readers.id=entrustment.readerId where readers.active=1 and entrustment.active=1 group by name+' '+surname"; //inner join birleştirme işlemidir yani entrustment tablosuyla readers tablosu idlerinin üstünde birleşiyor ama ikisinin de activelerinin 1 olması şarıtıyla ve isim ve soy isime göre grupluyorki aynı isim ve soyisim birden fazla gözükmesin
                    break;
                case 1:
                    query = "select bookName as X,COUNT(*) as Y from entrustment inner join books on books.id=entrustment.bookId group by bookName";
                    break;
                case 2:
                    query = "select authorName as X,COUNT(*) as Y from entrustment inner join books on books.id=entrustment.bookId group by authorName";
                    break;

                case 3:
                    query = "select type as X,COUNT(*) as Y from entrustment inner join books on books.id=entrustment.bookId group by type";
                    break;


                default:
                    break;
            }

            foreach(var series in chart.Series)//daha önce eklenmiş pointler varsa diye temizleme işlemi
            {
                series.Points.Clear();
            }


            foreach (DataRow row  in IDataBasee.DataToDataTable(query).Rows)
            {
                chart.Series["Situation"].Points.AddXY(row["X"].ToString(), row["Y"].ToString());
            }
        }

        private void cbbStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {
            LookStatistics();
        }
    }
}
