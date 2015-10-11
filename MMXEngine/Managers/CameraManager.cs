using Microsoft.Xna.Framework;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Windows.Managers
{
    public class CameraManager : ICameraManager
    {
        public float Zoom { get; set; }
        public float Rotation { get; set; }
        public Matrix Transform { get; private set; }
        public Matrix InverseTransform { get; private set; }
        public Vector2 Position { get; set; }

        public CameraManager()
        {
            Transform = new Matrix();
            InverseTransform = new Matrix();
            Position = Vector2.Zero;
            Zoom = 2.5f;
        }

        public void Update()
        {
            Zoom = MathHelper.Clamp(Zoom, 0.0f, 10.0f);
            Rotation = ClampAngle(Rotation);
            Transform = Matrix.CreateRotationZ(Rotation)*
                        Matrix.CreateScale(new Vector3(Zoom, Zoom, 1))*
                        Matrix.CreateTranslation(Position.X, Position.Y, 0);

            InverseTransform = Matrix.Invert(Transform);
        }

        private float ClampAngle(float radians)
        {
            while (radians < -MathHelper.Pi)
            {
                radians += MathHelper.TwoPi;
            }
            while (radians > MathHelper.Pi)
            {
                radians -= MathHelper.TwoPi;
            }
            return radians;
        }

    }
}
