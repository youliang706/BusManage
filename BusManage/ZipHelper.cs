using System;
using System.Diagnostics;
using System.IO;

namespace BusManage
{
    class ZipHelper
    {
        public void ZipFile(string targetName, string sourceName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string _7zaPath = path + "7za.exe";

            if (!File.Exists(_7zaPath))
            {
                _7zaPath = AppDomain.CurrentDomain.BaseDirectory + "7za.exe";
            }

            // 1
            // Initialize process information.
            //
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = _7zaPath;

            // 2
            // Use 7-zip
            // specify a=archive and -tgzip=gzip
            // and then target file in quotes followed by source file in quotes
            //
            //p.Arguments = "a -tgzip \"" + targetName + "\" \"" + sourceName + "\" -mx=9";
            p.Arguments = "a -t7z \"" + targetName + "\" \"" + sourceName + "\"";
            p.WindowStyle = ProcessWindowStyle.Hidden;

            // 3.
            // Start process and wait for it to exit
            //
            Process x = Process.Start(p);
            x.WaitForExit();            
        }
    }
}
