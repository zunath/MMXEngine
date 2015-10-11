﻿using MMXEngine.Common.Enumerations;
using MMXEngine.Interfaces.Components;

namespace MMXEngine.Interfaces.Managers
{
    public interface IInputManager
    {
        bool IsPressed(GameButton button);
        bool IsDown(GameButton button);
        bool IsUp(GameButton button);
        void Update();
        void SetConfiguration(IButtonConfiguration configuration);
    }
}
