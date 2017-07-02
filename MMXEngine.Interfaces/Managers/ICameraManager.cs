using Microsoft.Xna.Framework;

namespace MMXEngine.Contracts.Managers
{
    public interface ICameraManager
    {
        float Zoom { get; set; }
        float Rotation { get; set; }
        Matrix Transform { get; }
        Matrix InverseTransform { get; }
        Vector2 Position { get; set; }
        Vector2 Origin { get; }
        Vector2 TopLeft { get; }
        Vector2 TopRight { get; }
        Vector2 BottomLeft { get; }
        Vector2 BottomRight { get; }

        Vector2 WorldToScreen(Vector2 position);
        Vector2 WorldToScreen(float x, float y);
        Vector2 ScreenToWorld(Vector2 screenPosition);
        Vector2 ScreenToWorld(float screenX, float screenY);

        void Focus(Vector2 position);
        void Focus(float x, float y);

        void Move(float directionX, float directionY);
        void Move(Vector2 direction);
    }
}
