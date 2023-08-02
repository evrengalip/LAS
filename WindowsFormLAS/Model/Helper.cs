using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormLAS.Model
{
     class Helper
    {
        public static string profilePath(int ReaderId)
        {//kullanıcının kayıtlı fotoğrafı var mı yok mu ona bakıyor
            string path = Application.StartupPath + "/profile/" + ReaderId + ".jpg";

            if (File.Exists(path))//eğer bu yolda bir dosya varsa true yoksa false döndürüyor
            {
                return path;
            }
            return Application.StartupPath+"/profile/user_profile.png";
        }

    }
}
