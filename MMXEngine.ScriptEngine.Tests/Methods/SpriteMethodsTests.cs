using Artemis;
using Microsoft.Xna.Framework;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;
using MMXEngine.ScriptEngine.Methods;
using MMXEngine.Testing.Shared;
using NUnit.Framework;

namespace MMXEngine.ScriptEngine.Tests.Methods
{
    [TestFixture]
    public class SpriteMethodsTests
    {
        private SpriteMethods _spriteMethods;

        [SetUp]
        public void SetUp()
        {
            _spriteMethods = new SpriteMethods();
        }

        private Entity BuildEntity()
        {
            EntityWorld world = TestHelpers.CreateEntityWorld();
            Entity entity = world.CreateEntity();
            Sprite sprite = new Sprite();
            entity.AddComponent(sprite);

            return entity;
        }

        [Test]
        public void Sprite_ShouldHaveNullColorOverride()
        {
            Entity entity = BuildEntity();
            Assert.IsNull(entity.GetComponent<Sprite>().ColorOverride);
        }

        [Test]
        public void SetColorPalette_ShouldBeRed()
        {
            Entity entity = BuildEntity();
            _spriteMethods.SetColorPalette(entity, ColorType.Red);

            Color? color = entity.GetComponent<Sprite>().ColorOverride;
            Assert.IsNotNull(color);

            ColorTypeAttribute attr = ColorType.Red.GetAttributeOfType<ColorTypeAttribute>();

            Assert.AreEqual(attr.Red, color.Value.R);
            Assert.AreEqual(attr.Green, color.Value.G);
            Assert.AreEqual(attr.Blue, color.Value.B);
            Assert.AreEqual(attr.Alpha, color.Value.A);
        }

        [Test]
        public void SetColorPalette_ShouldBeCustom()
        {
            Entity entity = BuildEntity();
            _spriteMethods.SetColorPaletteCustom(entity, 50, 60, 70, 80);

            Color? color = entity.GetComponent<Sprite>().ColorOverride;
            Assert.IsNotNull(color);

            Assert.AreEqual(color.Value.R, 50);
            Assert.AreEqual(color.Value.G, 60);
            Assert.AreEqual(color.Value.B, 70);
            Assert.AreEqual(color.Value.A, 80);
        }

        [Test]
        public void ResetColorPalette_ShouldBeNull()
        {
            Entity entity = BuildEntity();
            _spriteMethods.SetColorPalette(entity, ColorType.Black);
            Assert.IsNotNull(entity.GetComponent<Sprite>().ColorOverride);
            _spriteMethods.ResetColorPalette(entity);
            Assert.IsNull(entity.GetComponent<Sprite>().ColorOverride);
        }
    }
}
