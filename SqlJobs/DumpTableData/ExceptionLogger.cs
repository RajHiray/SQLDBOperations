using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DumpTableData
{
    class ExceptionLogger
    {
        /// <summary>
        /// Write Exception In ExceptionError.txt File.
        /// </summary>
        /// <param name="ex"> Exception Object to be Write in File</param>
        public static void WriteException(Exception ex)
        {
            try
            {
                // Get Current Directory
                string workingDirectory = Environment.CurrentDirectory;

                // This will get the current PROJECT directory
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                string filePath = projectDirectory+"/ExceptionError.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();
                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);
                        ex = ex.InnerException;
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception in Exception Logger!!!!" + exc.Message);
            }
        }
    }
}
