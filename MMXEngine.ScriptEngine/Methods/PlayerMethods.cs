using System;
using Artemis;
using Artemis.System;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;

namespace MMXEngine.ScriptEngine.Methods
{
    public class PlayerMethods: IPlayerMethods
    {
        public bool IsPlayerShooting()
        {
            try
            {
                Entity player = (Entity) EntitySystem.BlackBoard.GetEntry("Player");
                return player.GetComponent<PlayerCharacter>().IsShooting;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
