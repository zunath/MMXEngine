using Artemis;
using MMXEngine.Contracts.Factories;
using MMXEngine.ECS.Components;
using MMXEngine.ScriptEngine.Methods;
using MMXEngine.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace MMXEngine.ScriptEngine.Tests.Methods
{
    [TestFixture]
    public class LevelMethodsTests
    {
        private LevelMethods _levelMethods;

        [SetUp]
        public void SetUp()
        {
            Mock<IEntityFactory> entityFactory = new Mock<IEntityFactory>();
            _levelMethods = new LevelMethods(entityFactory.Object);
        }

        private Entity BuildMapEntity()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            Map mapComponent = new Map
            {
                Height = 20,
                Width = 32
            };
            entity.AddComponent(mapComponent);

            return entity;
        }

        [Test]
        public void GetMapWidth_ShouldEqualTo32()
        {
            Entity map = BuildMapEntity();
            int width = _levelMethods.GetMapWidth(map);

            Assert.AreEqual(width, 32);
        }

        [Test]
        public void GetMapWidth_NoComponent_ShouldReturnNegative1()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            int width = _levelMethods.GetMapWidth(entity);
            Assert.AreEqual(width, -1);
        }

        [Test]
        public void GetMapHeight_ShouldBeEqualTo20()
        {
            Entity map = BuildMapEntity();
            int height = _levelMethods.GetMapHeight(map);
            Assert.AreEqual(height, 20);
        }

        [Test]
        public void GetMapHeight_NoComponent_ShouldReturnNegative1()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            int height = _levelMethods.GetMapHeight(entity);
            Assert.AreEqual(height, -1);
        }
    }
}
