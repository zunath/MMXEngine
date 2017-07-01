using System.Collections.Generic;
using MMXEngine.ECS.Components;
using NUnit.Framework;

namespace MMXEngine.ECS.Tests.Components
{
    [TestFixture]
    public class AnimationTests
    {
        private readonly Animation _animation;

        public AnimationTests()
        {
            _animation = new Animation
            {
                Frames = new List<Frame>()
            };

            for (int x = 0; x < 10; x++)
            {
                _animation.Frames.Add(new Frame());
            }
        }

        [Test]
        public void Animation_CurrentFrameID_ShouldBeZero()
        {
            _animation.CurrentFrameID = 10;
            Assert.AreEqual(_animation.CurrentFrameID, 0);
        }

        [Test]
        public void Animation_CurrentFrameID_ShouldBe9()
        {
            _animation.CurrentFrameID = -1;
            Assert.AreEqual(_animation.CurrentFrameID, 9);
        }

        [Test]
        public void Animation_CurrentFrameID_ShouldBe5()
        {
            _animation.CurrentFrameID = 5;
            Assert.AreEqual(_animation.CurrentFrameID, 5);
        }
    }
}
