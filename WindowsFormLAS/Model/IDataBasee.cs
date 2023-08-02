using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WinFormLAS.Modell
{
     class IDataBasee
    {
		public static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=LASDb;Integrated Security=True";
        public static DataTable DataToDataTable(string query, List<SqlParameter> parameters)
        {//veri okuma işlemi yapıyor sonra da verileri datatable olarak geri döndürüyor
			try
			{
				SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=LASDb;Integrated Security=True");
				SqlCommand cmd=new SqlCommand(query, con);
				if(parameters != null )
				{
					cmd.Parameters.AddRange(parameters.ToArray());
				}
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				DataTable dt= new DataTable();
				da.Fill(dt);

				return dt;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
        }

		public static DataTable DataToDataTable(string query, SqlParameter parameter)
		{//queryi   sadece 1 parametre alarak da çalıştırabilmek için
			return DataToDataTable(query, new List<SqlParameter>() { parameter });
		}

        public static DataTable DataToDataTable(string query)
		{//queryi parametre almadan da çalıştırabilmek için
			 return DataToDataTable(query,new List<SqlParameter>() { });
		}

		public static void ExecuteNonQuery(string query, List<SqlParameter> parameters)
		{//veri ekleme işlemi yapıyor
			SqlConnection con = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand(query, con);
			con.Open();
			try
			{
				if(parameters != null )
				{
					cmd.Parameters.AddRange (parameters.ToArray());
				}
				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{

				throw ex;
			}
			finally { con.Close(); }
		}

        public static void ExecuteNonQuery(string query,SqlParameter parameter)
		{//tek bir parametre alarak ekleme işlemi yapıyor
			ExecuteNonQuery(query, new List<SqlParameter>() { parameter });
		}


        public static object ExecuteScalar(string query, List<SqlParameter> parameters)
        {// executenonquery gibi veri eklememizi sağlıyor ama veri eklendikten sonra bir parametre döndürecekse bir parametre döndürmemizi sağlıyor ve sonuç olarak object tipinde bir değer döndürüyor
			object value = null;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            try
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                value=cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally { con.Close(); }
			return value;
        }
    }
}
