using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileProcessor;
using DataModel.Classes;

namespace CSVFileProcessor_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FileParserTest()
        {
            IFileParser fileParser = new FileParser();
            IBaseFile baseFileType = new LPFileType();
            var output=fileParser.ParseFile(string.Empty, baseFileType);
            Assert.IsNull(output);
        }
    }
}
