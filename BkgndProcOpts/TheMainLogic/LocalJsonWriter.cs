using System;
using System.IO;

namespace TheMainLogic
{
    public class LocalJsonWriter : IJsonWriter
    {
        private string _directory;

        public LocalJsonWriter(string destinationDirectory)
        {
            if (!Directory.Exists(destinationDirectory))
                throw new DirectoryNotFoundException(string.Format("{0} does not exist!!", destinationDirectory));
            _directory = destinationDirectory;
        }
        public string Write(string jsonText)
        {
            var fileName = Path.Combine(_directory, Guid.NewGuid().ToString("N") + ".json");
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(jsonText);
                sw.Close();
            }
            return fileName;
        }
    }
}
