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
            PlayerCharacter characterComponent = new PlayerCharacter
            {
                IsShooting = true
            };
            entity.AddComponent(characterComponent);

            PlayerStats stats = new PlayerStats();
            entity.AddComponent(stats);

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
            EntitySystem.BlackBoard.GetEntry<Entity>("Player").GetComponent<PlayerCharacter>().IsShooting = false;
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

        [Test]
        public void GetPlayerNumberOfLives_ShouldBeZero()
        {
            BuildValidEntity();
            _playerMethods.SetPlayerNumberOfLives(-200);
            int lives = _playerMethods.GetPlayerNumberOfLives();
            Assert.AreEqual(lives, 0);
        }

        [Test]
        public void GetPlayerNumberOfLives_ShouldBeFive()
        {
            BuildValidEntity();
            _playerMethods.SetPlayerNumberOfLives(5);
            int lives = _playerMethods.GetPlayerNumberOfLives();
            Assert.AreEqual(lives, 5);

        }

        [Test]
        public void GetPlayerNumberOfLives_ShouldBeNine()
        {
            BuildValidEntity();
            _playerMethods.SetPlayerNumberOfLives(8383);
            int lives = _playerMethods.GetPlayerNumberOfLives();
            Assert.AreEqual(lives, 9);
        }

    }
}
