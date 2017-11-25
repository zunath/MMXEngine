using System;
using Microsoft.Xna.Framework.Graphics;

namespace MMXEngine.Windows.Editor.Interop
{
	/// <summary>
	/// The <see cref="Microsoft.Xna.Framework.Content.ContentManager"/> needs a <see cref="IGraphicsDeviceService"/> to be in the <see cref="System.ComponentModel.Design.IServiceContainer"/>. This class fulfills this purpose.
	/// </summary>
	public class WpfGraphicsDeviceService : IGraphicsDeviceService
	{
		#region Constructors

		/// <summary>
		/// Create a new instance of the dummy. The constructor will autom. add the instance itself to the <see cref="D3D11Host.Services"/> container of <see cref="host"/>.
		/// </summary>
		/// <param name="host"></param>
		public WpfGraphicsDeviceService(WpfGame host)
		{
			if (host == null)
				throw new ArgumentNullException(nameof(host));

			if (host.Services.GetService(typeof(IGraphicsDeviceService)) != null)
				throw new NotSupportedException("A graphics device service is already registered.");

			GraphicsDevice = host.GraphicsDevice;
			host.Services.AddService(typeof(IGraphicsDeviceService), this);
		}

        #endregion

        #region Events

        #pragma warning disable 67
        [Obsolete("Dummy implementation will never call DeviceCreated")]
		public event EventHandler<EventArgs> DeviceCreated;

		[Obsolete("Dummy implementation will never call DeviceDisposing")]
		public event EventHandler<EventArgs> DeviceDisposing;

		[Obsolete("Dummy implementation will never call DeviceReset")]
		public event EventHandler<EventArgs> DeviceReset;

		[Obsolete("Dummy implementation will never call DeviceResetting")]
		public event EventHandler<EventArgs> DeviceResetting;

        #pragma warning restore 67

        #endregion

        #region Properties

        public GraphicsDevice GraphicsDevice { get; }

		#endregion
	}
}