using MMXEngine.Contracts.Entities;

namespace MMXEngine.Contracts.Managers
{
    public interface IScreenManager
    {
        void ChangeScreen(IScreen screen);
        void Update();
        void Draw();

    }
}
