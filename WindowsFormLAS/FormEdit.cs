using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormLAS.Modell;

namespace WindowsFormLAS
{
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
        }
        int rowId = 0;
        string GetTableName()
        {
            switch (cbbTableName.SelectedIndex)
            {
                case 0:
                    return "authors";
                case 1:
                    return "publishers";
                case 2:
                    return "types";
                case 3:
                    return "cupboards";



                default:return "";
            }

          
        }

        void TableLoad()
        {
            if (!string.IsNullOrEmpty(GetTableName()))//bir table seçilmişse
            {
                dg.DataSource=IDataBasee.DataToDataTable("select * from " + GetTableName());
                dg.Columns["id"].Visible = false;
            }

        }

        void Add()
        {
            IDataBasee.ExecuteNonQuery("insert into "+ GetTableName() +" (name) values (@name)", new SqlParameter("@name", SqlDbType.VarChar) { Value = txtName.Text });
            TableLoad();
            MessageBox.Show("insertion successful");
        }


        void Updatee()
        {
            List<SqlParameter >parameters =new List<SqlParameter>();// burda 2 parametre göndericez onun için lise oluşturdum
            parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value=txtName.Text});
            parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value=rowId});
            IDataBasee.ExecuteNonQuery("update " + GetTableName() + " set name=@name where id=@id", parameters);
            TableLoad();

            MessageBox.Show("update process successful ");
        }

        void Delete()
        {
            var query = $"delete {GetTableName()} where id=@id";

            IDataBasee.ExecuteNonQuery(query, new SqlParameter("@id", SqlDbType.Int) { Value = rowId });
            Clear();
            TableLoad();
            
            MessageBox.Show("Delete process successful");

        }

        void Clear()
        {
            rowId = 0;
            txtName.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {

        }

        private void cbbTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(GetTableName()))
            {
                MessageBox.Show("Select a table");
                return;
            }
            if (rowId > 0)
            {
                Update();
            }
            else { Add(); }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                rowId= Convert.ToInt32(dg.Rows[e.RowIndex].Cells["id"].Value);
                txtName.Text= dg.Rows[e.RowIndex].Cells["name"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rowId > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected line?", "Delete row", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Delete();
                }
            }
            else
            {
                MessageBox.Show("Select a row");
            }
        }
    }
}
