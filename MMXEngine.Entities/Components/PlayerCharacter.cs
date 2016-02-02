using Artemis.Interface;
using MMXEngine.Common.Enumerations;

namespace MMXEngine.ECS.Components
{
    public class PlayerCharacter: IComponent
    {
        public CharacterType CharacterType { get; set; }
    }
}
