using System;
using Microsoft.Xna.Framework.Input;
using MMXEngine.Common.Enumerations;
using MMXEngine.Interfaces.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Windows.Managers
{
    public class InputManager : IInputManager
    {
        private KeyboardState _lastFrameKBState;
        private KeyboardState _currentKBState;
        private IButtonConfiguration Configuration { get; set; }

        public bool IsPressed(GameButton button)
        {
            Keys key = ButtonToKey(button);
            return _currentKBState.IsKeyUp(key) &&
                _lastFrameKBState.IsKeyDown(key);
        }

        public bool IsDown(GameButton button)
        {
            Keys key = ButtonToKey(button);
            return _currentKBState.IsKeyDown(key);
        }

        public bool IsUp(GameButton button)
        {
            Keys key = ButtonToKey(button);
            return _currentKBState.IsKeyUp(key);
        }

        public void Update()
        {
            _lastFrameKBState = _currentKBState;
            _currentKBState = Keyboard.GetState();
        }

        public void SetConfiguration(IButtonConfiguration configuration)
        {
            if (Configuration == null)
            {
                Configuration = configuration;
            }
            else
            {
                throw new Exception("SetConfiguration - Configuration is already set!");
            }
        }


        private Keys ButtonToKey(GameButton button)
        {
            switch (button)
            {
                case GameButton.Dash: return Configuration.Dash;
                case GameButton.Jump: return Configuration.Jump;
                case GameButton.Menu: return Configuration.Menu;
                case GameButton.Shoot: return Configuration.Shoot;
                case GameButton.MoveDown: return Configuration.MoveDown;
                case GameButton.MoveLeft: return Configuration.MoveLeft;
                case GameButton.MoveRight: return Configuration.MoveRight;
                case GameButton.MoveUp: return Configuration.MoveUp;
                default: throw new Exception("GameButton not mapped to Key.");
            }
        }


    }
}
