using System;
using Artemis;
using Artemis.System;
using MMXEngine.Common.Attributes;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;

namespace MMXEngine.ScriptEngine.Methods
{
    /// <summary>
    /// Script methods used for manipulating player entities..
    /// </summary>
    [ScriptNamespace("Player")]
    public class PlayerMethods: IPlayerMethods
    {
        /// <summary>
        /// Returns whether the player is currently shooting.
        /// </summary>
        /// <returns>True if player is shooting. False otherwise.</returns>
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

        /// <summary>
        /// Returns the current number of player lives.
        /// </summary>
        /// <returns>The number of player lives.</returns>
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

        /// <summary>
        /// Sets the player's current number of lives.
        /// </summary>
        /// <param name="value">The number of lives to set. Must be between 0-9.</param>
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
