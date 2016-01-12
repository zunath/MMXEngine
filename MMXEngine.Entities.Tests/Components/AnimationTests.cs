using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.Tests.Components
{
    [TestClass]
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

        [TestMethod]
        public void Animation_CurrentFrameID_ShouldBeZero()
        {
            _animation.CurrentFrameID = 10;
            Assert.AreEqual(_animation.CurrentFrameID, 0);
        }

        [TestMethod]
        public void Animation_CurrentFrameID_ShouldBe9()
        {
            _animation.CurrentFrameID = -1;
            Assert.AreEqual(_animation.CurrentFrameID, 9);
        }

        [TestMethod]
        public void Animation_CurrentFrameID_ShouldBe5()
        {
            _animation.CurrentFrameID = 5;
            Assert.AreEqual(_animation.CurrentFrameID, 5);
        }
    }
}
