using Artemis.Interface;
using Microsoft.Xna.Framework.Input;
using MMXEngine.Interfaces.Components;

namespace MMXEngine.ECS.Components
{
    public class ButtonConfiguration : IComponent, IButtonConfiguration
    {
        public Keys MoveLeft { get; set; }
        public Keys MoveRight { get; set; }
        public Keys MoveUp { get; set; }
        public Keys MoveDown { get; set; }
        public Keys Jump { get; set; }
        public Keys Dash { get; set; }
        public Keys Shoot { get; set; }
        public Keys Menu { get; set; }

        public Keys ToggleMusic { get; set; }
    }
}
