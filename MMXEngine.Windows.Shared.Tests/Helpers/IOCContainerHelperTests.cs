using Autofac;
using MMXEngine.Windows.Shared.Helpers;
using NUnit.Framework;

namespace MMXEngine.Windows.Shared.Tests.Helpers
{
    [TestFixture]
    public class IOCContainerHelperTests
    {

        [Test]
        public void IOCContainerHelper_RegisterGameEntities_DoesNotThrow()
        {
            var container = new ContainerBuilder();

            Assert.DoesNotThrow(() =>
            {
                IOCContainerHelper.RegisterGameEntities(container);
            });
        }
        [Test]
        public void IOCContainerHelper_RegisterComponents_DoesNotThrow()
        {
            var container = new ContainerBuilder();

            Assert.DoesNotThrow(() =>
            {
                IOCContainerHelper.RegisterComponents(container);
            });
        }
        [Test]
        public void IOCContainerHelper_RegisterPlayerStates_DoesNotThrow()
        {
            var container = new ContainerBuilder();

            Assert.DoesNotThrow(() =>
            {
                IOCContainerHelper.RegisterPlayerStates(container);
            });
        }
        [Test]
        public void IOCContainerHelper_RegisterSystems_DoesNotThrow()
        {
            var container = new ContainerBuilder();

            Assert.DoesNotThrow(() =>
            {
                IOCContainerHelper.RegisterSystems(container);
            });
        }
        [Test]
        public void IOCContainerHelper_RegisterScreens_DoesNotThrow()
        {
            var container = new ContainerBuilder();

            Assert.DoesNotThrow(() =>
            {
                IOCContainerHelper.RegisterScreens(container);
            });
        }
    }
}
