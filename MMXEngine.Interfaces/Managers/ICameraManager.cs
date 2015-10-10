using Microsoft.Xna.Framework;

namespace MMXEngine.Interfaces.Managers
{
    public interface ICameraManager
    {
        void Initialize(Vector3 cameraPosition);
        Matrix ViewMatrix { get; }
        Matrix ProjectionMatrix { get; }
    }
}
