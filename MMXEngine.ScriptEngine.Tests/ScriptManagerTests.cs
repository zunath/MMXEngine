using System;
using System.IO;
using NUnit.Framework;

namespace MMXEngine.ScriptEngine.Tests
{
    [TestFixture]
    public class ScriptManagerTests
    {
        private ScriptManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = new ScriptManager();
        }

        [Test]
        public void QueueScript_ShouldNotThrowExceptions()
        {
            string tempFilePath = "./Scripts/TestFile.lua";
            Directory.CreateDirectory("./Scripts");
            FileStream stream = File.Create(tempFilePath);
            stream.Close();
            Assert.DoesNotThrow(delegate
            {
                _manager.QueueScript("TestFile.lua", null);
            });
            File.Delete(tempFilePath);
            Directory.Delete("./Scripts");
        }

        [Test]
        public void QueueScript_NoFile_ShouldThrowException()
        {
            Assert.Throws(typeof(FileNotFoundException), delegate
            {
                _manager.QueueScript("nonexistentfile.lua", null);
            });
        }

        [Test]
        public void ExecuteScript_ShouldNotThrowException()
        {
            string tempFilePath = "./Scripts/TestScript.lua";
            string scriptBody = "function Main() end";
            Directory.CreateDirectory("./Scripts");
            File.WriteAllText(tempFilePath, scriptBody);

            Assert.DoesNotThrow(delegate
            {
                _manager.QueueScript("TestScript.lua", null);
                _manager.ExecuteScripts();
            });
            

            File.Delete(tempFilePath);
            Directory.Delete("./Scripts");
        }

    }
}
