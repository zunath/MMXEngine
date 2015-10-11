using MMXEngine.Interfaces.Entities;

namespace MMXEngine.Interfaces.Managers
{
    public interface IScreenManager
    {
        void ChangeScreen(IScreen screen);
        void Update();
        void Draw();

    }
}
