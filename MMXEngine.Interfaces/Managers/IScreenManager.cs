using Microsoft.Xna.Framework;

namespace MMXEngine.Interfaces.Managers
{
    public interface IScreenManager
    {
        void Update(GameTime gameTime);
        void Draw();
    }
}
