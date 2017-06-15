using Artemis;
using MMXEngine.ECS.Components;
using MMXEngine.ScriptEngine.Methods;
using MMXEngine.Testing.Shared;
using NUnit.Framework;

namespace MMXEngine.ScriptEngine.Tests.Methods
{
    [TestFixture]
    public class MiscellaneousMethodsTests
    {
        private MiscellaneousMethods _miscellaneousMethods;

        [SetUp]
        public void SetUp()
        {
            _miscellaneousMethods = new MiscellaneousMethods();
        }

        [Test]
        public void Print_ShouldNotThrowException()
        {
            Assert.DoesNotThrow(
                delegate {
                    _miscellaneousMethods.Print("Test");
            });
        }

        [Test]
        public void GetScriptName_ShouldReturnValue()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            Script scriptComponent = new Script
            {
                FilePath = "TestScriptName"
            };
            entity.AddComponent(scriptComponent);
            string result = _miscellaneousMethods.GetScriptName(entity);
            Assert.AreEqual(result, "TestScriptName");
        }

        [Test]
        public void GetScriptName_NoComponent_ShouldReturnEmptyString()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            string result = _miscellaneousMethods.GetScriptName(entity);
            Assert.AreEqual(result, string.Empty);
        }
    }
}
