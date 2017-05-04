using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ActiveIDMan
{
    class FakeLicense
    {
        public void Fake(string name, string email, string serial)
        {
            
                string namefile = "SOFTWARE\\DownloadManager";
                Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(namefile);
                string idmPath = registryKey.GetValue("ExePath", "").ToString().Replace("IDMan.exe", "IDMGrHlp.exe");
                byte[] exeBytes1 = Properties.Resources.IDMGrHlp;
                using (FileStream exeFile = new FileStream(idmPath, FileMode.Create))
                    exeFile.Write(exeBytes1, 0, exeBytes1.Length);



                //fake license
                RegistryKey curren = Registry.CurrentUser.OpenSubKey("SOFTWARE\\DownloadManager", true);
                curren.SetValue("FName", name);
                curren.SetValue("LName", "---Active by ActiveIDMan");
                curren.SetValue("Email", email);
                curren.SetValue("Serial", serial);


                //Add to startup
                byte[] exeBytes = Properties.Resources.ActiveIDM;
                string exeToRun = Path.Combine(Path.GetTempPath(), "ActiveIDM.exe");
                using (FileStream exeFile = new FileStream(exeToRun, FileMode.Create))
                    exeFile.Write(exeBytes, 0, exeBytes.Length);
                RegistryKey add = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                add.SetValue("ActiveIDMan", "\"" + exeToRun + "\"");



                //message thanh cong
                MessageBox.Show("Đã Active Internet Download Manager thành công!\n" +
                                "Giờ thì mở IDM lên và xài thôi ^^! ");
            
            //catch (Exception e)
            //{
            //    MessageBox.Show("Đã có lỗi, hãy chắc là bạn đã chạy tool dưới quyền quản trị!");
            //}
        }
    }
}
