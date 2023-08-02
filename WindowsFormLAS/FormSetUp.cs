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
    public partial class FormSetUp : Form
    {
        public FormSetUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)||string.IsNullOrEmpty(txtSurname.Text)|| 
                string.IsNullOrEmpty(txtUsername.Text)|| 
                string.IsNullOrEmpty(txtPassword.Text)|| 
                string.IsNullOrEmpty(txtPasswordAgain.Text))
            {
                MessageBox.Show("Fill in All Fields");
                return;
            }

            if (txtPassword.Text != txtPasswordAgain.Text)
            {
                MessageBox.Show("Password Repeats Don't Match!");
                return;
            }

            List<SqlParameter>parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@name", SqlDbType.VarChar) { Value=txtName.Text });
            parameters.Add(new SqlParameter("@surname", SqlDbType.VarChar) { Value = txtSurname.Text });
            parameters.Add(new SqlParameter("@username", SqlDbType.VarChar) { Value = txtUsername.Text });
            parameters.Add(new SqlParameter("@password", SqlDbType.VarChar) { Value = txtPassword.Text });
            IDataBasee.ExecuteNonQuery("insert into users(name,surname,username,password)values(@Name,@Surname,@Username,@Password)",parameters);

            FormLogin formLogin = new FormLogin();
            formLogin.Show();// veriler girildikten sonra form login ekranının açılmasi için

            this.Hide();//setup ekranını kapatmak için
        }
    }
}
