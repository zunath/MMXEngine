using Microsoft.Xna.Framework;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Components;

namespace MMXEngine.Contracts.Managers
{
    public interface IInputManager
    {
        bool IsPressed(GameButton button);
        bool IsDown(GameButton button);
        bool IsUp(GameButton button);
        bool WasDownLastFrame(GameButton button);
        bool WasUpLastFrame(GameButton button);
        void Update();
        void SetConfiguration(IButtonConfiguration configuration);


        bool IsLeftMouseDown();
        bool IsLeftMouseUp();
        bool IsRightMouseDown();
        bool IsRightMouseUp();
        bool IsLeftMousePressed();
        bool IsRightMousePressed();

        Vector2 GetMousePosition();

    }
}
