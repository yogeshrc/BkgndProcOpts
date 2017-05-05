using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace TheMainLogic
{
    public class LocalXmlProvider : IXmlProvider
    {
        private readonly LocalXmlProviderEnumerator _enumerator;

        public LocalXmlProvider(string xmlDirectoryPath)
        {
            var files = new DirectoryInfo(xmlDirectoryPath).EnumerateFiles();
            _enumerator = new LocalXmlProviderEnumerator(files.Where(f => f.Extension.Equals(".xml", StringComparison.InvariantCultureIgnoreCase)));
        }

        public IEnumerator<XmlNode> GetEnumerator()
        {
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class LocalXmlProviderEnumerator : IEnumerator<XmlNode>
        {
            private int _index;
            private List<XmlDocument> _listOfMockXmls;

            public LocalXmlProviderEnumerator(IEnumerable<FileInfo> enumerable)
            {
                _listOfMockXmls = enumerable.Select(f =>
                {
                var doc = new XmlDocument();
                doc.LoadXml(File.ReadAllText(f.FullName));
                return doc;
                }).ToList();
            }

            public XmlNode Current
            {
                get
                {
                    return _listOfMockXmls[_index].DocumentElement;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                _listOfMockXmls = null;
            }

            public bool MoveNext()
            {
                _index++;
                return (_index < _listOfMockXmls.Count);
            }

            public void Reset()
            {
                _index = 0;
            }
        }
    }
}
