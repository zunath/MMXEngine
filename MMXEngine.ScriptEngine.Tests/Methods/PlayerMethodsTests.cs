using Artemis;
using Artemis.System;
using MMXEngine.ECS.Components;
using MMXEngine.ScriptEngine.Methods;
using MMXEngine.Testing.Shared;
using NUnit.Framework;

namespace MMXEngine.ScriptEngine.Tests.Methods
{
    [TestFixture]
    public class PlayerMethodsTests
    {
        private PlayerMethods _playerMethods;

        [SetUp]
        public void SetUp()
        {
            _playerMethods = new PlayerMethods();
        }

        private void BuildValidEntity()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            PlayerAction actionComponent = new PlayerAction
            {
                IsShooting = true
            };
            entity.AddComponent(actionComponent);
            EntitySystem.BlackBoard.SetEntry("Player", entity);
        }

        private void BuildInvalidEntity()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            EntitySystem.BlackBoard.SetEntry("Player", entity);
        }
        
        [Test]
        public void IsPlayerShooting_ShouldBeTrue()
        {
            BuildValidEntity();
            bool isPlayerShooting = _playerMethods.IsPlayerShooting();
            Assert.IsTrue(isPlayerShooting);
        }

        [Test]
        public void IsPlayerShooting_ShouldBeFalse()
        {
            BuildValidEntity();
            EntitySystem.BlackBoard.GetEntry<Entity>("Player").GetComponent<PlayerAction>().IsShooting = false;
            bool isPlayerShooting = _playerMethods.IsPlayerShooting();
            Assert.IsFalse(isPlayerShooting);
        }

        [Test]
        public void IsPlayerShooting_InvalidPlayer_ShouldBeFalse()
        {
            BuildInvalidEntity();
            bool isPlayerShooting = _playerMethods.IsPlayerShooting();
            Assert.IsFalse(isPlayerShooting);
        }
    }
}
