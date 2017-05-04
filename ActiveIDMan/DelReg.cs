using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.Win32;

namespace ActiveIDMan
{
    class DelReg
    {
        public void XoaReg()
        {
            Process[] runingProcess = Process.GetProcesses();
            try
            {
                for (int i = 0; i < runingProcess.Length; i++)
                {
                    if (runingProcess[i].ProcessName == "IDMan")
                    {
                        runingProcess[i].Kill();
                    }
                    
                }
            }
            catch (Exception e)
            {

            }
            //////////////////////////////
            
            string[] keyArray1 =
            {
                "Classes\\Wow6432Node\\CLSID\\{7B8E9164-324D-4A2E-A46D-0165FB2000EC}",
                "Classes\\Wow6432Node\\CLSID\\{5ED60779-4DE2-4E07-B862-974CA4FF2E9C}",
                "Classes\\CLSID\\{7B8E9164-324D-4A2E-A46D-0165FB2000EC}",
                "Classes\\CLSID\\{5ED60779-4DE2-4E07-B862-974CA4FF2E9C}",
                "Classes\\CLSID\\{07999AC3-058B-40BF-984F-69EB1E554CA7}",
                "Classes\\CLSID\\{6DDF00DB-1234-46EC-8356-27E7B2051192}",
                "Classes\\CLSID\\{D5B91409-A8CA-4973-9A0B-59F713D25671}"
            };
            foreach (var myKey1 in keyArray1)
            {
                try
                {
                    RegistryKey classes = Registry.CurrentUser.OpenSubKey("Software", true);
                    classes.DeleteSubKey(myKey1);

                }
                catch (Exception e)
                {

                }
            }

            
            string[] keyArray2 =
            {
                "CheckUpdtVM", "scansk", "tvfrdt", "FName", "LName", "Email", "Serial"
            };
            foreach (var myKey2 in keyArray2)
            {
                try
                {
                    RegistryKey idm = Registry.CurrentUser.OpenSubKey("Software\\DownloadManager", true);
                    idm.DeleteValue(myKey2);
                }
                catch (Exception e)
                {

                }
            }



            //////////////////////////////
            
            string[] keyArray3 =
            {
                "Classes\\CLSID\\{7B8E9164-324D-4A2E-A46D-0165FB2000EC}",
                "Classes\\CLSID\\{5ED60779-4DE2-4E07-B862-974CA4FF2E9C}",
                "Classes\\CLSID\\{07999AC3-058B-40BF-984F-69EB1E554CA7}",
                "Classes\\CLSID\\{6DDF00DB-1234-46EC-8356-27E7B2051192}",
                "Classes\\CLSID\\{D5B91409-A8CA-4973-9A0B-59F713D25671}",
                "Classes\\Wow6432Node\\CLSID\\{7B8E9164-324D-4A2E-A46D-0165FB2000EC}",
                "Classes\\Wow6432Node\\CLSID\\{5ED60779-4DE2-4E07-B862-974CA4FF2E9C}",
                "Wow6432Node\\Internet Download Manager",
                "Internet Download Manager"
            };
            foreach (var myKey3 in keyArray3)
            {
                try
                {
                    RegistryKey classeseLocal = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                    classeseLocal.DeleteSubKey(myKey3);
                }
                catch (Exception e)
                {

                }
            }
            
            ///////////////////////////////
            
            string[] keyArray4 =
            {
                "FName", "LName", "Email", "Serial"
            };
            foreach (var mykey4 in keyArray4)
            {
                try
                {
                    RegistryKey user =
                        Registry.Users.OpenSubKey(
                            "S-1-5-21-2754736582-2265559669-3571272114-1001\\Software\\DownloadManager");
                    user.DeleteValue(mykey4);
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
