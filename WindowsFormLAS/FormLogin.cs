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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", SqlDbType.VarChar) { Value=txtUsername.Text});
            parameters.Add(new SqlParameter("@password", SqlDbType.VarChar) { Value = txtPassword.Text });


            //querye users tablosuna git ve aktif users içerisinde set ettiğim username ve passworda uygun olan kullanıcıyı getir
            //(akitifi kullanmamın sebebi yanlışlıkla veriler silinmesin diye verilerin silinmesini istediğim zaman activei 0 yapıcam)
            DataTable dt = IDataBasee.DataToDataTable(
                "select * from users where active=1 and username= @username and password=@password", parameters);

            if(dt.Rows.Count > 0 )//bir kullanıcı varsa yani veri gelmişse
            {
                foreach (DataRow row in dt.Rows)//datarow tipinde row adli bir nesne tanımladık dt.rowsu gezicek
                {
                    UserInfo.userId = Convert.ToInt32(row["id"]);//kullanıcı varsa kullanıcının idsini userid adlı bir değişkene atıyorum çünkü ilerde lazım olabilir
                }

                FormMain formMain = new FormMain();
                formMain.Show();//formmain ekranına yönlendir

                this.Hide();
            }
            else//bir kullanıcı yoktur yani bir veri gelmemiştir sqlden, ya kullanıcı yoktur ya da kullanıcıadı ve şifresi yanlış girilmiştir
            {
                MessageBox.Show("User Not Found!");
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
