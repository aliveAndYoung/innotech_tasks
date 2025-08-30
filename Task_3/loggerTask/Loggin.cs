using System;
using System.IO;
using System.Text;
using System.Threading;

namespace FileLogger
{
    public class PeriodicFileLogger
    {
        private readonly string _filePath = "periodicallyUpdatedData.txt";

        public void AppendWithTimestamp(string text)
        {
            try
            {
                string timestamp = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]";
                string newEntry = $"{timestamp}\n [  \n {text}\n ] \n\n  ";

                string oldContent = File.Exists(_filePath)
                    ? File.ReadAllText(_filePath, Encoding.UTF8)
                    : string.Empty;

                string updatedContent = newEntry + oldContent;

                File.WriteAllText(_filePath, updatedContent, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }
    }
}
