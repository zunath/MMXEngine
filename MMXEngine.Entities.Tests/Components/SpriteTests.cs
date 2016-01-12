using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.Tests.Components
{
    [TestClass]
    public class SpriteTests
    {
        [TestMethod]
        public void Sprite_InitialAnimations_NotNull()
        {
            Sprite sprite = new Sprite();
            Assert.IsNotNull(sprite.Animations);
        }
    }
}
