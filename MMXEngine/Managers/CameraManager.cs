using Microsoft.Xna.Framework;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Windows.Managers
{
    public class CameraManager : ICameraManager
    {
        private readonly IGraphicsManager _graphicsManager;

        public CameraManager(IGraphicsManager graphicsManager)
        {
            _graphicsManager = graphicsManager;
        }

        // Initialize camera view/projection matrices.
        public void Initialize(Vector3 cameraPosition)
        {
            ViewMatrix = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, _graphicsManager.AspectRatio, 1.0f, 10000.0f);
        }

        public Matrix ViewMatrix { get; private set; }
        public Matrix ProjectionMatrix { get; private set; }
    }
}
