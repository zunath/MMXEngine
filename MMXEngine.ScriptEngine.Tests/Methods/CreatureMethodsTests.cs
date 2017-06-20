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
    public class CreatureMethodsTests
    {
        private EntityMethods _entityMethods;

        [SetUp]
        public void SetUp()
        {
            Mock<IEntityFactory> mockFactory = new Mock<IEntityFactory>();
            _entityMethods = new EntityMethods(mockFactory.Object);
        }

        [Test]
        public void GetPlayer_ShouldReturnPlayerObject()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity player = world.CreateEntity();
            EntitySystem.BlackBoard.SetEntry("Player", player);
            Entity result = _entityMethods.GetPlayer();

            Assert.AreSame(player, result);
        }

        [Test]
        public void GetPlayer_ShouldReturnNull()
        {
            Entity result = _entityMethods.GetPlayer();
            Assert.IsNull(result);
        }
        
        private Entity BuildPlayerEntity(CharacterType charType)
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
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
            CharacterType type = _entityMethods.GetCharacterType(player);
            Assert.AreEqual(type, CharacterType.X);
        }

        [Test]
        public void GetCharacterType_ShouldBeZero()
        {
            Entity player = BuildPlayerEntity(CharacterType.Zero);
            CharacterType type = _entityMethods.GetCharacterType(player);
            Assert.AreEqual(type, CharacterType.Zero);
        }

        [Test]
        public void GetCharacterType_ShouldBeUnknown()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity notAPlayer = world.CreateEntity();
            CharacterType type = _entityMethods.GetCharacterType(notAPlayer);
            Assert.AreEqual(type, CharacterType.Unknown);
        }

        [Test]
        public void GetCurrentHitPoints_ShouldBe50()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            int hp = _entityMethods.GetCurrentHitPoints(player);
            Assert.AreEqual(hp, 50);
        }

        [Test]
        public void GetCurrentHitPoints_ShouldBeNegative1()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity notAnEntityWithHealth = world.CreateEntity();
            int hp = _entityMethods.GetCurrentHitPoints(notAnEntityWithHealth);
            Assert.AreEqual(hp, -1);
        }

        [Test]
        public void GetMaxHitPoints_ShouldBe100()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            int hp = _entityMethods.GetMaxHitPoints(player);
            Assert.AreEqual(hp, 100);
        }

        [Test]
        public void GetMaxHitPoints_ShouldBeNegative1()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity notAnEntityWithHealth = world.CreateEntity();
            int hp = _entityMethods.GetMaxHitPoints(notAnEntityWithHealth);
            Assert.AreEqual(hp, -1);
        }

        [Test]
        public void ApplyDamage_ResultHPShouldBe10()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            int result = _entityMethods.ApplyDamage(player, 40);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void ApplyDamage_NoHealthComponent_ResultHPShouldBeNegative1()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entityWithoutHealth = world.CreateEntity();
            int result = _entityMethods.ApplyDamage(entityWithoutHealth, 10);
            Assert.AreEqual(result, -1);
        }

        [Test]
        public void GetIsHostile_IsHostile()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            player.AddComponent(new Hostile());
            bool isHostile = _entityMethods.GetIsHostile(player);
            Assert.AreEqual(isHostile, true);
        }

        [Test]
        public void GetIsHostile_NotHostile()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            bool isHostile = _entityMethods.GetIsHostile(player);
            Assert.AreEqual(isHostile, false);
        }

        [Test]
        public void GetIsHostile_Exception_ShouldBeNotHostile()
        {
            bool isHostile = _entityMethods.GetIsHostile(null);
            Assert.AreEqual(isHostile, false);
        }
    }
}
