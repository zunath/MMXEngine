using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;
using MMXEngine.Windows.Shared.Managers;
using NUnit.Framework;

namespace MMXEngine.Windows.Game.Tests.Managers
{
    [TestFixture]
    public class DataManagerTests
    {
        private DataManager _data;
        private IFileSystem _fileSystem;

        [SetUp]
        public void SetUp()
        {
            _fileSystem = new MockFileSystem();
            _data = new DataManager(_fileSystem);
        }

        [Test]
        public void DataManager_SaveLoadTileData_ShouldMatch()
        {
            TileData data = new TileData
            {
                X = 32,
                Y = 50,
                IsCollidable = true
            };

            _data.Save("data.dat", data);
            TileData retrievedData = _data.Load<TileData>("data.dat");

            Assert.AreEqual(32, retrievedData.X);
            Assert.AreEqual(50, retrievedData.Y);
            Assert.AreEqual(true, retrievedData.IsCollidable);
        }

        [Test]
        public void DataManager_SaveLoadLevelData_ShouldMatch()
        {
            LevelData data = new LevelData(20, 50)
            {
                BGMFile = "bgmFile.mp3",
                Script = "levelScript.lua",
                Spritesheet = "spritesheet.png",
                Name = "Test Level",
                Tiles = new TileData[50,20]
            };

            _data.Save("data.dat", data);
            LevelData retrievedData = _data.Load<LevelData>("data.dat");

            Assert.AreEqual("bgmFile.mp3", retrievedData.BGMFile);
            Assert.AreEqual("levelScript.lua", retrievedData.Script);
            Assert.AreEqual(50, retrievedData.Height);
            Assert.AreEqual(20, retrievedData.Width);
            Assert.AreEqual("spritesheet.png", retrievedData.Spritesheet);
            Assert.AreEqual("Test Level", retrievedData.Name);
            Assert.AreEqual(new TileData[50, 20], retrievedData.Tiles);
        }

        [Test]
        public void DataManager_SaveLoadItemData_ShouldMatch()
        {
            ItemData data = new ItemData()
            {
                Script = "itemScript.lua",
                Name = "Test Item",
                CollisionHeight = 40,
                CollisionWidth = 20,
                CollisionOffsetX = 5,
                CollisionOffsetY = -4,
                HeartbeatInterval = 6.0f,
                TextureFile = "texture.png",
                Animations = new List<Animation>()
            };

            _data.Save("data.dat", data);
            ItemData retrievedData = _data.Load<ItemData>("data.dat");

            Assert.AreEqual("itemScript.lua", retrievedData.Script);
            Assert.AreEqual("Test Item", retrievedData.Name);
            Assert.AreEqual(40, retrievedData.CollisionHeight);
            Assert.AreEqual(20, retrievedData.CollisionWidth);
            Assert.AreEqual(5, retrievedData.CollisionOffsetX);
            Assert.AreEqual(-4, retrievedData.CollisionOffsetY);
            Assert.AreEqual(6.0f, retrievedData.HeartbeatInterval);
            Assert.AreEqual("texture.png", retrievedData.TextureFile);
            Assert.AreEqual(new List<Animation>(), retrievedData.Animations);
        }
        [Test]
        public void DataManager_SaveLoadCreatureData_ShouldMatch()
        {
            CreatureData data = new CreatureData()
            {
                Script = "creatureScript.lua",
                Name = "Test Creature",
                CollisionHeight = 40,
                CollisionWidth = 20,
                CollisionOffsetX = 5,
                CollisionOffsetY = -4,
                HeartbeatInterval = 6.0f,
                TextureFile = "texture.png",
                Animations = new List<Animation>()
            };

            _data.Save("data.dat", data);
            CreatureData retrievedData = _data.Load<CreatureData>("data.dat");

            Assert.AreEqual("creatureScript.lua", retrievedData.Script);
            Assert.AreEqual("Test Creature", retrievedData.Name);
            Assert.AreEqual(40, retrievedData.CollisionHeight);
            Assert.AreEqual(20, retrievedData.CollisionWidth);
            Assert.AreEqual(5, retrievedData.CollisionOffsetX);
            Assert.AreEqual(-4, retrievedData.CollisionOffsetY);
            Assert.AreEqual(6.0f, retrievedData.HeartbeatInterval);
            Assert.AreEqual("texture.png", retrievedData.TextureFile);
            Assert.AreEqual(new List<Animation>(), retrievedData.Animations);
        }
        [Test]
        public void DataManager_SaveLoadPlayerData_ShouldMatch()
        {
            PlayerData data = new PlayerData()
            {
                Script = "player.lua",
                Name = "Test Player",
                CollisionHeight = 40,
                CollisionWidth = 20,
                CollisionOffsetX = 5,
                CollisionOffsetY = -4,
                HeartbeatInterval = 6.0f,
                TextureFile = "texture.png",
                Animations = new List<Animation>(),
                MaxDashLength = 10.0f,
                DashSpeed = 2.5f,
                GravitySpeed = 4.0f,
                JumpSpeed = 15.0f,
                MaxFallSpeed = 8.0f,
                MaxJumpLength = 2.0f,
                MaxNumberOfJumps = 42,
                MoveSpeed = 1.5f
            };

            _data.Save("data.dat", data);
            PlayerData retrievedData = _data.Load<PlayerData>("data.dat");

            Assert.AreEqual("player.lua", retrievedData.Script);
            Assert.AreEqual("Test Player", retrievedData.Name);
            Assert.AreEqual(40, retrievedData.CollisionHeight);
            Assert.AreEqual(20, retrievedData.CollisionWidth);
            Assert.AreEqual(5, retrievedData.CollisionOffsetX);
            Assert.AreEqual(-4, retrievedData.CollisionOffsetY);
            Assert.AreEqual(6.0f, retrievedData.HeartbeatInterval);
            Assert.AreEqual("texture.png", retrievedData.TextureFile);
            Assert.AreEqual(new List<Animation>(), retrievedData.Animations);
            Assert.AreEqual(10.0f, retrievedData.MaxDashLength);
            Assert.AreEqual(2.5f, retrievedData.DashSpeed);
            Assert.AreEqual(4.0f, retrievedData.GravitySpeed);
            Assert.AreEqual(15.0f, retrievedData.JumpSpeed);
            Assert.AreEqual(8.0f, retrievedData.MaxFallSpeed);
            Assert.AreEqual(2.0f, retrievedData.MaxJumpLength);
            Assert.AreEqual(42, retrievedData.MaxNumberOfJumps);
            Assert.AreEqual(1.5f, retrievedData.MoveSpeed);
        }

        [Test]
        public void DataManager_NoDirectoryExists_ShouldCreateDirectory()
        {
            if (_fileSystem.Directory.Exists(".\\Data\\"))
            {
                _fileSystem.Directory.Delete(".\\Data\\");
            }
            
            _data.Save("testData.dat", "some test data");

            Assert.IsTrue(_fileSystem.Directory.Exists(".\\Data\\"));
        }

        [Test]
        public void DataManager_LoadDataNoFileExists_ShouldThrowException()
        {
            Assert.Throws<FileNotFoundException>(() =>
            {
                _data.Load<string>("noFileExists.dat");
            });
        }
    }
}
