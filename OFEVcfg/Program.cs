using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace OFEVcfg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\WOW6432Node\\ubisoft\\silent hunter 5\\gameupdate"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("installdir");
                        if (o != null)
                        {   // OFEVcfg
                            string location = o.ToString();
                            location = @location.TrimEnd(new[] { '\\' });
                            FileStream fs2 = new FileStream("OptionsFileEditorViewer.cfg", FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer2 = new StreamWriter(fs2);
                            string newline1 = @"SH5InstallPath=" + @location;
                            string newline2 = @"LastMenuTXT=" + @location + @"\data\Menu\menu.txt";
                            string newline3 = @"LastOptionsFilePath=" + @location + @"\data\Scripts\Menu\";
                            string newline4 = @"ClientAreaWidth=1014";
                            string newline5 = @"ClientAreaHeight=736";
                            string newline6 = @"LanguagePackInUse=";
                            writer2.WriteLine(newline1);
                            writer2.WriteLine(newline2);
                            writer2.WriteLine(newline3);
                            writer2.WriteLine(newline4);
                            writer2.WriteLine(newline5);
                            writer2.WriteLine(newline6);
                            writer2.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("There was an error reading the regkey");
                Console.ReadKey();
            }
        }
    }
}
