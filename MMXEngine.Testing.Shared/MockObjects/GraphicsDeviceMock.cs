using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;

namespace MMXEngine.Testing.Shared.MockObjects
{
    public class GraphicsDeviceMock
    {
        public static GraphicsDeviceMock Current { get; set; }

        private GraphicsDevice _graphicsDevice;
        private Form _hiddenForm;

        public GraphicsDeviceMock()
        {
            _hiddenForm = new Form()
            {
                Visible = false,
                ShowInTaskbar = false
            };

            var parameters = new PresentationParameters()
            {
                BackBufferWidth = 1280,
                BackBufferHeight = 720,
                DeviceWindowHandle = _hiddenForm.Handle,
                PresentationInterval = PresentInterval.Immediate,
                IsFullScreen = false
            };

            _graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, parameters);
        }

        public GraphicsDevice GraphicsDevice => _graphicsDevice;

        public void Release()
        {
            _graphicsDevice.Dispose();
            _graphicsDevice = null;

            _hiddenForm.Close();
            _hiddenForm.Dispose();
            _hiddenForm = null;
        }
    }
}
