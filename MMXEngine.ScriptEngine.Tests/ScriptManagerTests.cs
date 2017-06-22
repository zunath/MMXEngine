using System.IO;
using System.IO.Abstractions.TestingHelpers;
using MMXEngine.Contracts.ScriptMethods;
using Moq;
using NUnit.Framework;

namespace MMXEngine.ScriptEngine.Tests
{
    [TestFixture]
    public class ScriptManagerTests
    {
        private ScriptManager _manager;
        private MockFileSystem _fileSystem;

        [SetUp]
        public void Setup()
        {
            _fileSystem = new MockFileSystem();

            _manager = new ScriptManager(
                _fileSystem, 
                new Mock<IAudioMethods>().Object,
                new Mock<IEntityMethods>().Object,
                new Mock<ILevelMethods>().Object,
                new Mock<ILocalDataMethods>().Object,
                new Mock<IMiscellaneousMethods>().Object,
                new Mock<IPhysicsMethods>().Object,
                new Mock<IPlayerMethods>().Object,
                new Mock<ISpriteMethods>().Object);
        }

        [Test]
        public void QueueScript_ShouldNotThrowExceptions()
        {
            const string tempFilePath = ".\\Content\\Compiled\\Scripts\\TestFile.lua";
            _fileSystem.Directory.CreateDirectory(".\\Scripts\\");

            _fileSystem.AddFile(tempFilePath, "function Main() end");
            Assert.DoesNotThrow(delegate
            {
                _manager.QueueScript("TestFile.lua", null);
            });

            _fileSystem.RemoveFile(tempFilePath);
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
            const string tempFilePath = ".\\Content\\Compiled\\Scripts\\TestScript.lua";
            const string scriptBody = "function Main() end";
            _fileSystem.Directory.CreateDirectory(".\\Scripts");
            _fileSystem.AddFile(tempFilePath, scriptBody);

            Assert.DoesNotThrow(delegate
            {
                _manager.QueueScript("TestScript.lua", null);
                _manager.ExecuteScripts();
            });
            

            _fileSystem.RemoveFile(tempFilePath);
            _fileSystem.Directory.Delete(".\\Scripts");
        }

    }
}
