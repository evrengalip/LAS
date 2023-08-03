using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormLAS.Model;
using WinFormLAS.Modell;

namespace WindowsFormLAS
{
    public partial class FormAddReader : Form
    {

        int ReaderId = 0;//seçili olan kullanıcının id'sini tutacak
        string ReaderPhoto = "";//okuyucunun fotosunun yolunu tutar
        
        void AddReader()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@name", SqlDbType.VarChar) { Value = txtName.Text });
            parameters.Add(new SqlParameter("@surname", SqlDbType.VarChar) { Value = txtSurname.Text });
            string gender = "";
            if (radiobtnFemale.Checked)
            {
                gender = radiobtnFemale.Text;
            }
            else if (radiobtnMale.Checked)
            {
                gender=radiobtnMale.Text;
            }
            parameters.Add(new SqlParameter("@gender", SqlDbType.VarChar) { Value = gender });
            parameters.Add(new SqlParameter("@class", SqlDbType.VarChar) { Value = txtClass.Text });
            parameters.Add(new SqlParameter("@schoolNumber", SqlDbType.VarChar) { Value = txtSchoolNumber.Text });
            parameters.Add(new SqlParameter("@phoneNumber", SqlDbType.VarChar) { Value = maskedPhoneNumber.Text });
            parameters.Add(new SqlParameter("@adress", SqlDbType.VarChar) { Value = txtAdress.Text });


            object value=IDataBasee.ExecuteScalar("insert into readers (name,surname,gender,class,schoolNumber,phoneNumber,adress) values (@name,@surname,@gender,@class,@schoolNumber,@phoneNumber,@adress) select @@IDENTITY ", parameters);//okuyucu eklendikten sonra okuyucunun ıd'sini dündürmesi için select ıdentıty yazdık
            //object tipinde bir değer döndürdüğü için object tutan bir değişkene atamam lazım
            ReaderId=Convert.ToInt32(value);

            //MessageBox.Show(ReaderId.ToString());//to string'i sayısal bir ifadeyi metne dönüştürebilmesi için yazdık
            MessageBox.Show("okuyucu ekleme işlemi başarılı");
            PhotoSave();
            ReaderLoad();//her okuyucu eklendiğinde listeyi yenilemesi için ekledim
        }

        void UpdateReader()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@name", SqlDbType.VarChar) { Value = txtName.Text });
            parameters.Add(new SqlParameter("@surname", SqlDbType.VarChar) { Value = txtSurname.Text });
            string gender = "";
            if (radiobtnFemale.Checked)
            {
                gender = radiobtnFemale.Text;
            }
            else if (radiobtnMale.Checked)
            {
                gender = radiobtnMale.Text;
            }
            parameters.Add(new SqlParameter("@gender", SqlDbType.VarChar) { Value = gender });
            parameters.Add(new SqlParameter("@class", SqlDbType.VarChar) { Value = txtClass.Text });
            parameters.Add(new SqlParameter("@schoolNumber", SqlDbType.VarChar) { Value = txtSchoolNumber.Text });
            parameters.Add(new SqlParameter("@phoneNumber", SqlDbType.VarChar) { Value = maskedPhoneNumber.Text });
            parameters.Add(new SqlParameter("@adress", SqlDbType.VarChar) { Value = txtAdress.Text });
            parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = ReaderId});


            IDataBasee.ExecuteNonQuery("update readers set name=@name,surname=@surname,gender=@gender,class=@class,schoolNumber=@schoolNumber,phoneNumber=@phoneNumber,adress=@adress where id=@id", parameters);
           

           

            PhotoSave();
            ReaderLoad();//her okuyucu eklendiğinde listeyi yenilemesi için ekledim

            MessageBox.Show("okuyucu güncelleme işlemi başarılı");
        }


        void DeleteReader()
        {
            IDataBasee.ExecuteNonQuery("update readers set active=0 where id=@id",new SqlParameter("@id", SqlDbType.Int) { Value=ReaderId });
            Clear();
            ReaderLoad();
        }


        void Clear()
        {
            ReaderId = 0;
            ReaderPhoto = "";

            pictureProfile.ImageLocation = Helper.profilePath(0);//olmayan bir id set ediyoruz fotoğrafa,bu sayede ana fotoğraf kalıyor imageboxta
            radiobtnMale.Checked = false;
            radiobtnFemale.Checked = false;

            foreach (var item in tableLayoutPanel.Controls)
            {
                if(item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }

                if (item is MaskedTextBox)
                {
                    ((MaskedTextBox)item).Text = "";
                }
            }
        }

        void ReaderLoad()
        {
            dg.DataSource = IDataBasee.DataToDataTable("select * from readers where active=1 and name +' '+ surname like @search",
                new SqlParameter("@search", SqlDbType.VarChar) { Value = string.Format("%{0}%", txtFilter.Text)  });
            dg.Columns["id"].Visible = false;

        }

        void PhotoSave()//foto kayıt etme metodu
        {
            if (!string.IsNullOrEmpty(ReaderPhoto))//eğer bir fotoğraf seçilmişse
            {
                File.Copy(ReaderPhoto,Application.StartupPath+"/profile/"+ReaderId+".jpg", true);//Application.StartupPath=projenin çalıştığı dizinin yolunu döndürür(ReaderId isminde kayıt edicez ve jpg uzantılı olarak)(true dersek kaydediceğimiz adla olan dosya varsa dosyayı değiştirmemize izin verir
            }
        }

        public FormAddReader()
        {
            InitializeComponent();
        }

        private void FormAddReader_Load(object sender, EventArgs e)
        {
            ReaderLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             


            if(ReaderId>0)
            {
                UpdateReader();
            }
            else
            {
                AddReader();
            }
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "(*jpg)|*.jpg";//sadece jpg uzaantılı dosya seçmesi için filtreleme
            if (openFileDialog.ShowDialog() == DialogResult.OK)//eğer kullanıcı bir dosya seçmişse(openFileDialog.ShowDialog()=dosyalar kısmını açar)
            {
                ReaderPhoto=openFileDialog.FileName;//seçtiği dosyanın yolunu geri döndürür
                pictureProfile.ImageLocation = ReaderPhoto;
            }
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                ReaderId = Convert.ToInt32(dg.Rows[e.RowIndex].Cells["id"].Value);

                pictureProfile.ImageLocation = Helper.profilePath(ReaderId);

                radiobtnFemale.Checked =true;
                radiobtnMale.Checked = false;

                foreach (DataRow row in IDataBasee.DataToDataTable("select * from readers where active=1 and id=@id",new SqlParameter("@id", SqlDbType.Int) { Value=ReaderId}).Rows)
                {
                    txtName.Text = row["name"].ToString();
                    txtSurname.Text = row["surname"].ToString();
                    string gender = row["gender"].ToString();
                    if (gender==radiobtnMale.Text)
                    {
                        radiobtnMale.Checked = true;
                    }
                    else if (gender == radiobtnFemale.Text)
                    {
                        radiobtnFemale.Checked = true;
                    }                   
                    txtClass.Text = row["class"].ToString();
                    txtSchoolNumber.Text = row["schoolNumber"].ToString();
                    maskedPhoneNumber.Text = row["phoneNumber"].ToString();
                    txtAdress.Text = row["adress"].ToString();



                }
            }
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ReaderId>0)
            {
                DialogResult dialogResult =MessageBox.Show("Are you sure you want to delete the selected reader?","Delete Reader", MessageBoxButtons.YesNo);

                if(dialogResult == DialogResult.Yes)
                {
                    DeleteReader();
                }
                else
                {
                    MessageBox.Show(" the transaction is canceled");
                }
            }
            else
            {
                MessageBox.Show("Select a Reader");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ReaderLoad();
        }
    }

   
}
