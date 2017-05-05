using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheMainLogic.Tests
{
    [TestClass()]
    public class LocalXmlProviderTests
    {
        [TestMethod()]
        public void LocalXmlProviderTest()
        {
            Assert.Fail();
        }

        [TestMethod(), ExpectedException(typeof(System.IO.DirectoryNotFoundException))]
        public void GetEnumeratorTest()
        {
            new LocalXmlProvider(@"c:\temp\xmlprovidertest");
        }
    }
}