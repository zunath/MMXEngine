using System.ComponentModel;
using System.IO;
using System.IO.Abstractions.TestingHelpers;
using MMXEngine.Common.Attributes;
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

            var mockAudio = new Mock<IAudioMethods>();
            var mockEntity = new Mock<IEntityMethods>();
            var mockLevel = new Mock<ILevelMethods>();
            var mockLocalData = new Mock<ILocalDataMethods>();
            var mockMisc = new Mock<IMiscellaneousMethods>();
            var mockPhysics = new Mock<IPhysicsMethods>();
            var mockPlayer = new Mock<IPlayerMethods>();
            var mockSprite = new Mock<ISpriteMethods>();

            TypeDescriptor.AddAttributes(mockAudio.Object.GetType(), new ScriptNamespaceAttribute("Audio"));
            TypeDescriptor.AddAttributes(mockEntity.Object.GetType(), new ScriptNamespaceAttribute("Entity"));
            TypeDescriptor.AddAttributes(mockLevel.Object.GetType(), new ScriptNamespaceAttribute("Level"));
            TypeDescriptor.AddAttributes(mockLocalData.Object.GetType(), new ScriptNamespaceAttribute("LocalData"));
            TypeDescriptor.AddAttributes(mockMisc.Object.GetType(), new ScriptNamespaceAttribute("Misc"));
            TypeDescriptor.AddAttributes(mockPhysics.Object.GetType(), new ScriptNamespaceAttribute("Physics"));
            TypeDescriptor.AddAttributes(mockPlayer.Object.GetType(), new ScriptNamespaceAttribute("Player"));
            TypeDescriptor.AddAttributes(mockSprite.Object.GetType(), new ScriptNamespaceAttribute("Sprite"));

            _manager = new ScriptManager(
                _fileSystem, 
                mockAudio.Object,
                mockEntity.Object,
                mockLevel.Object,
                mockLocalData.Object,
                mockMisc.Object,
                mockPhysics.Object,
                mockPlayer.Object,
                mockSprite.Object);
        }

        [Test]
        public void QueueScript_ShouldNotThrowExceptions()
        {
            const string tempFilePath = ".\\Content\\Scripts\\TestFile.lua";
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
            const string tempFilePath = ".\\Content\\Scripts\\TestScript.lua";
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
