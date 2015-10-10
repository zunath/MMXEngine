using System;
using Microsoft.Xna.Framework.Graphics;
using XnaGraphicsDeviceManager = Microsoft.Xna.Framework.GraphicsDeviceManager;

namespace MMXEngine.Interfaces.Managers
{
    public interface IGraphicsManager
    {
        void Initialize(XnaGraphicsDeviceManager xnaGraphics);
        GraphicsDevice GraphicsDevice { get; }
        Single AspectRatio { get; }
        SpriteBatch SpriteBatch { get; }
    }
}
