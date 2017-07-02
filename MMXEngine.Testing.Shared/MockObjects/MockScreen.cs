using MMXEngine.Contracts.Entities;

namespace MMXEngine.Testing.Shared.MockObjects
{
    public class MockScreen: IScreen
    {
        public bool InitializeCalled { get; set; }
        public bool UpdateCalled { get; set; }
        public bool DrawCalled { get; set; }
        public bool CloseCalled { get; set; }

        public void Initialize()
        {
            InitializeCalled = true;
        }

        public void Update()
        {
            UpdateCalled = true;
        }

        public void Draw()
        {
            DrawCalled = true;
        }

        public void Close()
        {
            CloseCalled = true;
        }
    }
}
