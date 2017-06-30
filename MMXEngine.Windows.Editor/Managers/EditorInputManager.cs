using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Components;
using MMXEngine.Contracts.Managers;
using MMXEngine.Windows.Editor.Interop.Input;

namespace MMXEngine.Windows.Editor.Managers
{
    public class EditorInputManager: IInputManager
    {
        private readonly WpfMouse _mouse;
        private readonly WpfKeyboard _keyboard;

        private MouseState _lastMouseState;
        private MouseState _currentMouseState;

        private KeyboardState _lastFrameKBState;
        private KeyboardState _currentKBState;

        public EditorInputManager(EditorGame game)
        {
            _mouse = new WpfMouse(game);
            _keyboard = new WpfKeyboard(game);
        }

        public bool IsPressed(GameButton button)
        {
            return false;
        }

        public bool IsDown(GameButton button)
        {
            return false;
        }

        public bool IsUp(GameButton button)
        {
            return false;
        }

        public bool WasDownLastFrame(GameButton button)
        {
            return false;
        }

        public bool WasUpLastFrame(GameButton button)
        {
            return false;
        }

        public void Update()
        {
            _lastFrameKBState = _currentKBState;
            _lastMouseState = _currentMouseState;

            _currentKBState = _keyboard.GetState();
            _currentMouseState = _mouse.GetState();
        }

        public void SetConfiguration(IButtonConfiguration configuration)
        {

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
