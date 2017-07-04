using MMXEngine.Testing.Shared;
using MMXEngine.Testing.Shared.MockObjects;
using MMXEngine.Windows.Shared.Managers;
using NUnit.Framework;

namespace MMXEngine.Windows.Game.Tests.Managers
{
    [TestFixture]
    public class ScreenManagerTests
    {
        [Test]
        public void ScreenManager_Constructor_DoesNotThrow()
        {
            var world = TestHelpers.CreateEntityWorld();

            Assert.DoesNotThrow(() =>
            {
                // ReSharper disable once ObjectCreationAsStatement
                new ScreenManager(world);
            });
        }

        [Test]
        public void ScreenManager_ChangeScreen_ShouldRunInitialize()
        {
            var world = TestHelpers.CreateEntityWorld();
            var manager = new ScreenManager(world);
            MockScreen screen = new MockScreen();
            manager.ChangeScreen(screen);

            Assert.IsTrue(screen.InitializeCalled);
        }

        [Test]
        public void ScreenManager_Update_ShouldRunScreenUpdate()
        {
            var world = TestHelpers.CreateEntityWorld();
            var manager = new ScreenManager(world);
            MockScreen screen = new MockScreen();
            manager.ChangeScreen(screen);
            manager.Update();

            Assert.IsTrue(screen.UpdateCalled);
        }

        [Test]
        public void ScreenManager_Draw_ShouldRunScreenDraw()
        {
            var world = TestHelpers.CreateEntityWorld();
            var manager = new ScreenManager(world);
            MockScreen screen = new MockScreen();
            manager.ChangeScreen(screen);
            manager.Draw();

            Assert.IsTrue(screen.DrawCalled);
        }

    }
}
