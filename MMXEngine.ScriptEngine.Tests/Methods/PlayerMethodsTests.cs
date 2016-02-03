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
        private void BuildValidEntity()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            PlayerAction actionComponent = new PlayerAction
            {
                HasJumped = true,
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
        public void IsPlayerJumping_ShouldBeTrue()
        {
            BuildValidEntity();
            bool isJumping = PlayerMethods.IsPlayerJumping();
            Assert.IsTrue(isJumping);
        }

        [Test]
        public void IsPlayerJumping_ShouldBeFalse()
        {
            BuildValidEntity();
            EntitySystem.BlackBoard.GetEntry<Entity>("Player").GetComponent<PlayerAction>().HasJumped = false;
            bool isJumping = PlayerMethods.IsPlayerJumping();
            Assert.IsFalse(isJumping);
        }

        [Test]
        public void IsPlayerJumping_InvalidPlayer_ShouldBeFalse()
        {
            BuildInvalidEntity();
            bool isJumping = PlayerMethods.IsPlayerJumping();
            Assert.IsFalse(isJumping);
        }

        [Test]
        public void IsPlayerShooting_ShouldBeTrue()
        {
            BuildValidEntity();
            bool isPlayerShooting = PlayerMethods.IsPlayerShooting();
            Assert.IsTrue(isPlayerShooting);
        }

        [Test]
        public void IsPlayerShooting_ShouldBeFalse()
        {
            BuildValidEntity();
            EntitySystem.BlackBoard.GetEntry<Entity>("Player").GetComponent<PlayerAction>().IsShooting = false;
            bool isPlayerShooting = PlayerMethods.IsPlayerShooting();
            Assert.IsFalse(isPlayerShooting);
        }

        [Test]
        public void IsPlayerShooting_InvalidPlayer_ShouldBeFalse()
        {
            BuildInvalidEntity();
            bool isPlayerShooting = PlayerMethods.IsPlayerShooting();
            Assert.IsFalse(isPlayerShooting);
        }
    }
}
