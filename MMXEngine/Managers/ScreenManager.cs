using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Windows.Managers
{
    public class ScreenManager : IScreenManager
    {
        private IScreen _screen;

        public void ChangeScreen(IScreen screen)
        {
            _screen = screen;
            _screen.Initialize();
        }

        public void Update()
        {
            _screen.Update();
        }

        public void Draw()
        {
            _screen.Draw();
        }
    }
}
