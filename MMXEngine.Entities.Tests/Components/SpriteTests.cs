using MMXEngine.ECS.Components;
using NUnit.Framework;

namespace MMXEngine.ECS.Tests.Components
{
    [TestFixture]
    public class SpriteTests
    {
        [Test]
        public void Sprite_InitialAnimations_NotNull()
        {
            Sprite sprite = new Sprite();
            Assert.IsNotNull(sprite.Animations);
        }
    }
}
