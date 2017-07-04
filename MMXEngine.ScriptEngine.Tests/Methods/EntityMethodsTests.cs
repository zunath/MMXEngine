using System;
using Artemis;
using Artemis.System;
using Autofac;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Factories;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Entities;
using MMXEngine.ScriptEngine.Methods;
using MMXEngine.Testing.Shared;
using MMXEngine.Windows.Shared.Factories;
using Moq;
using NUnit.Framework;

namespace MMXEngine.ScriptEngine.Tests.Methods
{
    [TestFixture]
    public class EntityMethodsTests
    {
        private EntityWorld _world;
        private EntityMethods _methods;
        private Entity _mockEnemyWithPosition;
        private Entity _mockEnemyWithoutPosition;
        private Entity _mockItem;

        [SetUp]
        public void SetUp()
        {
            _world = TestHelpers.CreateEntityWorld();
            _mockEnemyWithPosition = _world.CreateEntity();
            _mockEnemyWithPosition.AddComponent(new Position());
            _mockEnemyWithoutPosition = _world.CreateEntity();
            _mockItem = _world.CreateEntity();
            
            Mock<IEntityFactory> mockFactory = new Mock<IEntityFactory>();
            mockFactory.Setup(x => x.Create<Enemy>("testName", It.IsAny<int>(), It.IsAny<int>()))
                .Returns(_mockEnemyWithPosition);
            mockFactory.Setup(x => x.Create<Enemy>("testWithoutPosition", It.IsAny<int>(), It.IsAny<int>()))
                .Returns(_mockEnemyWithoutPosition);
            mockFactory.Setup(x => x.Create<Item>("testName", It.IsAny<int>(), It.IsAny<int>()))
                .Returns(_mockItem);

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
        public void SetCurrentHitPoints_ShouldBeSetToMaximum()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            _methods.SetCurrentHitPoints(player, 5000);
            int hp = _methods.GetCurrentHitPoints(player);
            Assert.AreEqual(100, hp);
        }

        [Test]
        public void SetCurrentHitPoints_ShouldBeSetTo0()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            _methods.SetCurrentHitPoints(player, -4000);
            int hp = _methods.GetCurrentHitPoints(player);
            Assert.AreEqual(0, hp);
        }

        [Test]
        public void SetCurrentHitPoints_ShouldBeSetTo80()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            _methods.SetCurrentHitPoints(player, 80);
            int hp = _methods.GetCurrentHitPoints(player);
            Assert.AreEqual(80, hp);
        }

        [Test]
        public void SetCurrentHitPoints_NoComponent_ShouldNotThrow()
        {
            Entity notAnEntityWithHealth = _world.CreateEntity();
            Assert.DoesNotThrow(() =>
            {
                _methods.SetCurrentHitPoints(notAnEntityWithHealth, 50);
            });
        }

        [Test]
        public void SetMaxHitPoints_ShouldBeSetTo1()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            _methods.SetMaxHitPoints(player, -500);
            int hp = _methods.GetMaxHitPoints(player);
            Assert.AreEqual(1, hp);
        }

        [Test]
        public void SetMaxHitPoints_ShouldBeSetTo50()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            _methods.SetMaxHitPoints(player, 50);
            int hp = _methods.GetMaxHitPoints(player);
            Assert.AreEqual(50, hp);
        }

        [Test]
        public void SetMaxHitPoints_CurrentHP_ShouldBeSetTo30()
        {
            Entity player = BuildPlayerEntity(CharacterType.X);
            _methods.SetMaxHitPoints(player, 30);
            int hp = _methods.GetCurrentHitPoints(player);
            int maxHP = _methods.GetMaxHitPoints(player);
            Assert.AreEqual(30, hp);
            Assert.AreEqual(30, maxHP);
        }

        [Test]
        public void SetMaxHitPoints_NoComponent_ShouldNotThrow()
        {
            Entity player = _world.CreateEntity();
            Assert.DoesNotThrow(() =>
            {
                _methods.SetMaxHitPoints(player, 5000);
            });
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

        [Test]
        public void CreateEnemy_ShouldReturnEnemy()
        {
            Entity entity = _methods.CreateEnemy("testName", 0, 0, Direction.Right);
            Assert.IsNotNull(entity);
        }

        [Test]
        public void CreateEnemy_NoPositionComponent_ShouldReturnNull()
        {
            Entity entity = _methods.CreateEnemy("testWithoutPosition", 0, 0, Direction.Right);
            Assert.IsNull(entity);
        }

        [Test]
        public void CreateItem_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() =>
            {
                _methods.CreateItem("testName", 0, 0);
            });
        }

        [Test]
        public void CreateItem_ShouldReturnItem()
        {
            Entity entity = _methods.CreateItem("testName", 0, 0);
            Assert.IsNotNull(entity);
        }

        [Test]
        public void CreateItem_ThrowException_ShouldReturnNull()
        {
            var mockContext = new Mock<IComponentContext>();
            var methods = new EntityMethods(new EntityFactory(_world, mockContext.Object));

            Entity entity = methods.CreateItem("itemNotRegistered", 0, 0);
            Assert.IsNull(entity);
        }

        [Test]
        public void DestroyObject_Player_ShouldNotDestroy()
        {
            var originalPlayer = EntitySystem.BlackBoard.GetEntry("Player");

            Entity entity = _world.CreateEntity();
            EntitySystem.BlackBoard.SetEntry("Player", entity);
            _methods.DestroyObject(entity);

            Entity player = (Entity)EntitySystem.BlackBoard.GetEntry("Player");

            Assert.IsNotNull(player);
            Assert.IsTrue(player.IsActive);

            EntitySystem.BlackBoard.SetEntry("Player", originalPlayer);
        }

        [Test]
        public void DestroyObject_ShouldDestroy()
        {
            Entity entity = _world.CreateEntity();

            Assert.IsFalse(entity.DeletingState);
            _methods.DestroyObject(entity);
            Assert.IsTrue(entity.DeletingState);
        }
    }
}
