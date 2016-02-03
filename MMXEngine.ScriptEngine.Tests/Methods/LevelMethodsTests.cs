﻿using System.IO;
using Artemis;
using MMXEngine.ECS.Components;
using MMXEngine.ScriptEngine.Methods;
using MMXEngine.Testing.Shared;
using NUnit.Framework;
using TiledSharp;

namespace MMXEngine.ScriptEngine.Tests.Methods
{
    [TestFixture]
    public class LevelMethodsTests
    {
        private Entity BuildMapEntity()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();

            // TmxMap requires a file to be loaded and I can't mock it out.
            string tempFilePath = "./TestTMXFile.tmx";
            File.WriteAllText(tempFilePath, @"<?xml version=""1.0"" encoding=""UTF-8""?><map version=""1.0"" orientation=""orthogonal"" width=""32"" height=""20"" tilewidth=""32"" tileheight=""32""/>");
            TmxMap tmxMap = new TmxMap(tempFilePath);
            File.Delete(tempFilePath);
            
            Map mapComponent = new Map
            {
                LevelMap = tmxMap
            };
            entity.AddComponent(mapComponent);

            return entity;
        }

        [Test]
        public void GetMapWidth_ShouldEqualTo32()
        {
            Entity map = BuildMapEntity();
            int width = LevelMethods.GetMapWidth(map);

            Assert.AreEqual(width, 32);
        }

        [Test]
        public void GetMapWidth_NoComponent_ShouldReturnNegative1()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            int width = LevelMethods.GetMapWidth(entity);
            Assert.AreEqual(width, -1);
        }

        [Test]
        public void GetMapHeight_ShouldBeEqualTo20()
        {
            Entity map = BuildMapEntity();
            int height = LevelMethods.GetMapHeight(map);
            Assert.AreEqual(height, 20);
        }

        [Test]
        public void GetMapHeight_NoComponent_ShouldReturnNegative1()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            int height = LevelMethods.GetMapHeight(entity);
            Assert.AreEqual(height, -1);
        }
    }
}