using MMXEngine.Testing.Shared.MockObjects;
using NUnit.Framework;

namespace MMXEngine.Testing.Shared
{
    [SetUpFixture]
    public class AssemblyTestManager
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            GraphicsDeviceMock.Current = new GraphicsDeviceMock();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            GraphicsDeviceMock.Current.Release();
        }
    }
}
