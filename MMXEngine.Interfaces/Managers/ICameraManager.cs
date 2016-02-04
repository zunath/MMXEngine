using Microsoft.Xna.Framework;

namespace MMXEngine.Interfaces.Managers
{
    public interface ICameraManager
    {
        float Zoom { get; set; }
        float Rotation { get; set; }
        Matrix Transform { get; }
        Matrix InverseTransform { get; }
        Vector2 Position { get; set; }
        Vector2 Origin { get; }
        Vector2 ScreenCenter { get; }
        Vector2 Focus { get; set; }
        
        void Update();
    }
}
