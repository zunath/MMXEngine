using System;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Interfaces.Managers;
using XnaGraphicsDeviceManager = Microsoft.Xna.Framework.GraphicsDeviceManager;

namespace MMXEngine.Windows.Managers
{
    public class GraphicsManager :IGraphicsManager
    {
        private XnaGraphicsDeviceManager graphics;
        
        // Initialize all graphics properties.
        public void Initialize(XnaGraphicsDeviceManager xnaGraphics)
        {
            if (null != graphics)
            {
                return;
            }

            graphics = xnaGraphics;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            GraphicsDevice = graphics.GraphicsDevice;
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public GraphicsDevice GraphicsDevice { get; private set; }
        public Single AspectRatio => GraphicsDevice.Viewport.AspectRatio;
        public SpriteBatch SpriteBatch { get; private set; }
    }
}
