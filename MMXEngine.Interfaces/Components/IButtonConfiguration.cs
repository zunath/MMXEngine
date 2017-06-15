using Microsoft.Xna.Framework.Input;

namespace MMXEngine.Contracts.Components
{
    public interface IButtonConfiguration
    {
        Keys MoveLeft { get; set; }
        Keys MoveRight { get; set; }
        Keys MoveUp { get; set; }
        Keys MoveDown { get; set; }
        Keys Jump { get; set; }
        Keys Dash { get; set; }
        Keys Shoot { get; set; }
        Keys Menu { get; set; }

        Keys ToggleMusic { get; set; }
    }
}
