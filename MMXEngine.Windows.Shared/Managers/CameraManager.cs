using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Managers;
using MonoGame.Extended;

namespace MMXEngine.Windows.Shared.Managers
{
    public class CameraManager : ICameraManager
    {
        private readonly Camera2D _camera;

        public float Zoom
        {
            get => _camera.Zoom;
            set => _camera.Zoom = value;
        }

        public float Rotation
        {
            get => _camera.Rotation;
            set => _camera.Rotation = value;
        }

        public Matrix Transform => _camera.GetViewMatrix();
        public Matrix InverseTransform => _camera.GetInverseViewMatrix();

        public Vector2 Position
        {
            get => _camera.Position;
            set => _camera.Position = value;
        }

        public Vector2 Origin => _camera.Origin;

        public Vector2 TopLeft => ScreenToWorld(0f, 0f);
        public Vector2 TopRight => ScreenToWorld(_camera.BoundingRectangle.Right, 0f);
        public Vector2 BottomLeft => ScreenToWorld(0f, _camera.BoundingRectangle.Bottom);
        public Vector2 BottomRight => ScreenToWorld(_camera.BoundingRectangle.Right, _camera.BoundingRectangle.Bottom);

        public CameraManager(GraphicsDevice graphics)
        {
            _camera = new Camera2D(graphics);
            
            Position = Vector2.Zero;
            Zoom = 3.0f;
        }

        public Vector2 WorldToScreen(Vector2 position)
        {
            return _camera.WorldToScreen(position);
        }

        public Vector2 WorldToScreen(float x, float y)
        {
            return _camera.WorldToScreen(x, y);
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            return _camera.ScreenToWorld(screenPosition);
        }

        public Vector2 ScreenToWorld(float screenX, float screenY)
        {
            return _camera.ScreenToWorld(screenX, screenY);
        }

        public void Focus(Vector2 position)
        {
            _camera.LookAt(position);
        }

        public void Focus(float x, float y)
        {
            _camera.LookAt(new Vector2(x, y));
        }

        public void Move(float directionX, float directionY)
        {
            _camera.Move(new Vector2(directionX, directionY));
        }

        public void Move(Vector2 direction)
        {
            _camera.Move(direction);
        }
    }
}
