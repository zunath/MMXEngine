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

        public int GetPlayerNumberOfLives()
        {
            try
            {
                Entity player = (Entity) EntitySystem.BlackBoard.GetEntry("Player");
                return player.GetComponent<PlayerStats>().Lives;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void SetPlayerNumberOfLives(int value)
        {
            Entity player = (Entity) EntitySystem.BlackBoard.GetEntry("Player");
            if(player == null)
                throw new Exception("Player object has not been added to Artemis blackboard.");

            if(!player.HasComponent<PlayerStats>())
                throw new Exception("PlayerStats component not found on player object.");

            if (value > 9)
                value = 9;
            else if (value < 0)
                value = 0;

            PlayerStats stats = player.GetComponent<PlayerStats>();
            stats.Lives = value;
        }
    }
}
