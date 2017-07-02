using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MMXEngine.Windows.Editor.Contracts;
using MMXEngine.Windows.Editor.Interop.Input;

namespace MMXEngine.Windows.Editor.Managers
{
	public class EditorInputManager: IEditorInputManager
    {
        private WpfMouse _mouse;
        private WpfKeyboard _keyboard;

        private MouseState _lastMouseState;
        private MouseState _currentMouseState;

        private KeyboardState _lastFrameKBState;
        private KeyboardState _currentKBState;
		
	    public void Register(EditorGame game)
		{
			_mouse = new WpfMouse(game);
			_keyboard = new WpfKeyboard(game);
		}

	    public bool IsPressed(Keys key)
        {
	        return _currentKBState.IsKeyDown(key) &&
	               _lastFrameKBState.IsKeyDown(key);
        }

        public bool IsDown(Keys key)
        {
	        return _currentKBState.IsKeyDown(key);
        }

        public bool IsUp(Keys key)
        {
	        return _currentKBState.IsKeyUp(key);
        }

        public bool WasDownLastFrame(Keys key)
        {
	        return _lastFrameKBState.IsKeyDown(key);
        }

        public bool WasUpLastFrame(Keys key)
        {
	        return _lastFrameKBState.IsKeyUp(key);
        }

        public void Update()
        {
            _lastFrameKBState = _currentKBState;
            _lastMouseState = _currentMouseState;

            _currentKBState = _keyboard.GetState();
            _currentMouseState = _mouse.GetState();
        }
		
        public bool IsLeftMouseDown()
        {
            return _currentMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftMouseUp()
        {
            return _currentMouseState.LeftButton == ButtonState.Released;
        }

        public bool IsRightMouseDown()
        {
            return _currentMouseState.RightButton == ButtonState.Pressed;
        }

        public bool IsRightMouseUp()
        {
            return _currentMouseState.RightButton == ButtonState.Released;
        }

        public bool IsLeftMousePressed()
        {
            return _currentMouseState.LeftButton == ButtonState.Released &&
                   _lastMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool IsRightMousePressed()
        {
            return _currentMouseState.RightButton == ButtonState.Released &&
                   _lastMouseState.RightButton == ButtonState.Pressed;
        }

        public Vector2 GetMousePosition()
        {
            return _currentMouseState.Position.ToVector2();
        }



    }
}
