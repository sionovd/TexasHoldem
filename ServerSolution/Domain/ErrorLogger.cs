using System;
using System.IO;

namespace Domain
{
    public static class ErrorLogger
    {
        public static void LogError(Exception ex)
        {
            string strPath = "../../../ErrorFile.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("==================================== " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("==================================== " + DateTime.Now);
                sw.WriteLine();
            }
        }
    }
}
