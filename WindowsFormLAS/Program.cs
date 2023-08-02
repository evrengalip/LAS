using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormLAS.Modell;

namespace WindowsFormLAS
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormSetUp());
            Application.Run(new FormMain());//ilk olarak main ekran gelsinki sürekli kullancıı adı ve şifre girmeyelim

            /*if(IDataBasee.DataToDataTable("select * from users where active=1").Rows.Count > 0)
            {
                //kullanıcı var yani login ekranına yönlendir
                Application.Run(new FormLogin());
            }
            else { Application.Run(new FormSetUp()); }*/
        }
    }
}
