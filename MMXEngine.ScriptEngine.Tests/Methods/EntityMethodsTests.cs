using System;
using Artemis;
using Artemis.System;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Factories;
using MMXEngine.ECS.Components;
using MMXEngine.ScriptEngine.Methods;
using MMXEngine.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace MMXEngine.ScriptEngine.Tests.Methods
{
    [TestFixture]
    public class EntityMethodsTests
    {
        private EntityWorld _world;
        private EntityMethods _methods;

        [SetUp]
        public void SetUp()
        {
            _world = TestHelpers.CreateEntityWorld();
            Mock<IEntityFactory> mockFactory = new Mock<IEntityFactory>();
            _methods = new EntityMethods(mockFactory.Object);
        }
        
        [Test]
        public void GetPlayer_ShouldReturnPlayerObject()
        {
            Entity player = _world.CreateEntity();
            EntitySystem.BlackBoard.SetEntry("Player", player);
            Entity result = _methods.GetPlayer();

            Assert.AreSame(player, result);
        }

        [Test]
        public void GetPlayer_NoPlayer_ShouldReturnException()
        {
            Assert.Throws<Exception>(() =>
            {
                _methods.GetPlayer();
            });
        }


        [Test]
        public void GetName_ShouldReturnValue()
        {
            Entity entity = _world.CreateEntity();
            Nameable nameableComponent = new Nameable
            {
                Name = "MyName"
            };
            entity.AddComponent(nameableComponent);
            string name = _methods.GetName(entity);

            Assert.AreEqual(name, "MyName");
        }

        [Test]
        public void GetName_NoComponent_ShouldReturnEmptyString()
        {
            Entity entity = _world.CreateEntity();
            string name = _methods.GetName(entity);

            Assert.AreEqual(name, string.Empty);
        }


        private Entity BuildPlayerEntity(CharacterType charType)
        {
            Entity entity = _world.CreateEntity();
            PlayerCharacter playerComponent = new PlayerCharacter()
            {
                CharacterType = charType
            };
            entity.AddComponent(playerComponent);
            Health healthComponent = new Health
            {
                CurrentHitPoints = 50,
                MaxHitPoints = 100
            };
            entity.AddComponent(healthComponent);

            return entity;
        }

        [Test]
        public void GetCharacterType_ShouldBeX()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            CharacterType type = _methods.GetCharacterType(player);
            Assert.AreEqual(type, CharacterType.X);
        }

        [Test]
        public void GetCharacterType_ShouldBeZero()
        {
            Entity player = BuildPlayerEntity(CharacterType.Zero);
            CharacterType type = _methods.GetCharacterType(player);
            Assert.AreEqual(type, CharacterType.Zero);
        }

        [Test]
        public void GetCharacterType_ShouldBeUnknown()
        {
            Entity notAPlayer = _world.CreateEntity();
            CharacterType type = _methods.GetCharacterType(notAPlayer);
            Assert.AreEqual(type, CharacterType.Unknown);
        }

        [Test]
        public void GetCurrentHitPoints_ShouldBe50()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            int hp = _methods.GetCurrentHitPoints(player);
            Assert.AreEqual(hp, 50);
        }

        [Test]
        public void GetCurrentHitPoints_ShouldBeNegative1()
        {
            Entity notAnEntityWithHealth = _world.CreateEntity();
            int hp = _methods.GetCurrentHitPoints(notAnEntityWithHealth);
            Assert.AreEqual(hp, -1);
        }

        [Test]
        public void GetMaxHitPoints_ShouldBe100()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            int hp = _methods.GetMaxHitPoints(player);
            Assert.AreEqual(hp, 100);
        }

        [Test]
        public void GetMaxHitPoints_ShouldBeNegative1()
        {
            Entity notAnEntityWithHealth = _world.CreateEntity();
            int hp = _methods.GetMaxHitPoints(notAnEntityWithHealth);
            Assert.AreEqual(hp, -1);
        }

        [Test]
        public void ApplyDamage_ResultHPShouldBe10()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            int result = _methods.ApplyDamage(player, 40);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void ApplyDamage_NoHealthComponent_ResultHPShouldBeNegative1()
        {
            Entity entityWithoutHealth = _world.CreateEntity();
            int result = _methods.ApplyDamage(entityWithoutHealth, 10);
            Assert.AreEqual(result, -1);
        }

        [Test]
        public void GetIsHostile_IsHostile()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            player.AddComponent(new Hostile());
            bool isHostile = _methods.GetIsHostile(player);
            Assert.AreEqual(isHostile, true);
        }

        [Test]
        public void GetIsHostile_NotHostile()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            bool isHostile = _methods.GetIsHostile(player);
            Assert.AreEqual(isHostile, false);
        }

        [Test]
        public void GetIsHostile_Exception_ShouldBeNotHostile()
        {
            bool isHostile = _methods.GetIsHostile(null);
            Assert.AreEqual(isHostile, false);
        }

        [Test]
        public void CreateEnemy_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() =>
            {
                _methods.CreateEnemy("testName", 0, 0, Direction.Right);
            });
        }
    }
}
