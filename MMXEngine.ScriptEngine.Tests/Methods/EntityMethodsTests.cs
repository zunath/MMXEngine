using Artemis;
using MMXEngine.ECS.Components;
using MMXEngine.ScriptEngine.Methods;
using MMXEngine.Testing.Shared;
using NUnit.Framework;

namespace MMXEngine.ScriptEngine.Tests.Methods
{
    [TestFixture]
    public class EntityMethodsTests
    {
        [Test]
        public void GetName_ShouldReturnValue()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            Nameable nameableComponent = new Nameable
            {
                Name = "MyName"
            };
            entity.AddComponent(nameableComponent);
            string name = EntityMethods.GetName(entity);

            Assert.AreEqual(name, "MyName");
        }

        [Test]
        public void GetName_NoComponent_ShouldReturnEmptyString()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            string name = EntityMethods.GetName(entity);

            Assert.AreEqual(name, string.Empty);
        }
    }
}
