using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;

namespace TheMainLogic
{
    public class TheMainProcess : SimsBackgroundProcess
    {
        private IXmlProvider _sourceProvider;
        private IJsonWriter _writer;

        public const string KEY_SOURCE_DIRECTORY = "SourceDirectory";
        public const string KEY_DESTINATION_DIRECTORY = "DestinationDirectory";

        protected override void Dispose()
        {
            //_writer.Write(jsonText).Write<ImageWriter>().Write<ZipWriter>()
        }

        protected override void Execute()
        {
            foreach (var item in _sourceProvider)
            {
                //convert XML to JSON
                var jsonText = JsonConvert.SerializeXmlNode(item);
                var jsonFile = _writer.Write(jsonText);
                //GZip json files
                using (FileStream fs = File.Create(jsonFile + ".gz"))
                {
                    using (GZipStream gzip = new GZipStream(fs, CompressionLevel.Optimal))
                    {
                        File.OpenRead(jsonFile).CopyTo(gzip);
                    }
                }
                Thread.Sleep(10000); //sleep for 10 seconds
            }
        }

        protected override bool Validate()
        {
            if (_configuration.Keys.FirstOrDefault(k => k.Equals(KEY_SOURCE_DIRECTORY, System.StringComparison.InvariantCultureIgnoreCase)) == null)
                return false;
            if (_configuration.Keys.FirstOrDefault(k => k.Equals(KEY_DESTINATION_DIRECTORY, System.StringComparison.InvariantCultureIgnoreCase)) == null)
                return false;
            if (string.IsNullOrEmpty(_configuration[KEY_SOURCE_DIRECTORY])) return false;
            if (string.IsNullOrEmpty(_configuration[KEY_DESTINATION_DIRECTORY])) return false;
            return true;
        }

        protected override void Initialize()
        {
            _sourceProvider = new LocalXmlProvider(_configuration[KEY_SOURCE_DIRECTORY]);
            _writer = new LocalJsonWriter(_configuration[KEY_DESTINATION_DIRECTORY]);
        }
    }
}
