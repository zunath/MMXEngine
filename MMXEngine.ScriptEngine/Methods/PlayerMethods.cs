using System;
using Artemis;
using Artemis.System;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.ScriptEngine.Methods
{
    public class PlayerMethods: IScriptMethodGroup
    {
        public static bool IsPlayerJumping()
        {
            try
            {
                Entity player = (Entity)EntitySystem.BlackBoard.GetEntry("Player");
                return player.GetComponent<PlayerAction>().HasJumped;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsPlayerShooting()
        {
            try
            {
                Entity player = (Entity) EntitySystem.BlackBoard.GetEntry("Player");
                return player.GetComponent<PlayerAction>().IsShooting;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
