using Microsoft.Xna.Framework;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using NUnit.Framework;

namespace MMXEngine.Common.Tests.Extensions
{
    [TestFixture]
    public class RectangleExtensionsTests
    {
        [Test]
        public void GetCollisionType_ShouldBeAbove()
        {
            Rectangle rect1 = new Rectangle(0, 0, 32, 32);
            Rectangle rect2 = new Rectangle(0, 10, 32, 32);

            CollisionType type = rect1.GetCollisionType(rect2);

            Assert.AreEqual(CollisionType.Top, type);
        }
        [Test]
        public void GetCollisionType_HasIntersection_ShouldBeBelow()
        {
            Rectangle rect1 = new Rectangle(0, 0, 32, 32);
            Rectangle rect2 = new Rectangle(0, -10, 32, 32);

            CollisionType type = rect1.GetCollisionType(rect2);

            Assert.AreEqual(CollisionType.Bottom, type);
        }
        [Test]
        public void GetCollisionType_HasIntersection_ShouldBeLeft()
        {
            Rectangle rect1 = new Rectangle(10, 0, 32, 32);
            Rectangle rect2 = new Rectangle(0, 0, 32, 32);

            CollisionType type = rect1.GetCollisionType(rect2);

            Assert.AreEqual(CollisionType.Left, type);
        }
        [Test]
        public void GetCollisionType_HasIntersection_ShouldBeRight()
        {
            Rectangle rect1 = new Rectangle(-10, 0, 32, 32);
            Rectangle rect2 = new Rectangle(0, 0, 32, 32);

            CollisionType type = rect1.GetCollisionType(rect2);

            Assert.AreEqual(CollisionType.Right, type);
        }
        [Test]
        public void GetCollisionType_NoIntersectionTouching_ShouldBeNone()
        {
            Rectangle rect1 = new Rectangle(0, 0, 32, 32);
            Rectangle rect2 = new Rectangle(32, 0, 32, 32);

            CollisionType type = rect1.GetCollisionType(rect2);

            Assert.AreEqual(CollisionType.None, type);
        }
        [Test]
        public void GetCollisionType_NoIntersectionNotTouching_ShouldBeNone()
        {
            Rectangle rect1 = new Rectangle(0, 0, 32, 32);
            Rectangle rect2 = new Rectangle(100, 0, 32, 32);

            CollisionType type = rect1.GetCollisionType(rect2);

            Assert.AreEqual(CollisionType.None, type);
        }
    }
}
