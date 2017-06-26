using System;
using Artemis;
using MMXEngine.Common.Attributes;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Entities;

namespace MMXEngine.ScriptEngine.Methods
{
    /// <summary>
    /// Script methods used for manipulating level data.
    /// </summary>
    [ScriptNamespace("Level")]
    public class LevelMethods: ILevelMethods
    {
        private readonly IEntityFactory _entityFactory;

        /// <summary>
        /// Constructor for the LevelMethods class.
        /// </summary>
        /// <param name="entityFactory">The factory used for creating entities.</param>
        public LevelMethods(IEntityFactory entityFactory)
        {
            _entityFactory = entityFactory;
        }

        /// <summary>
        /// Returns the width of the specified level. Returns -1 if entity is not a level.
        /// </summary>
        /// <param name="entity">The level to retrieve the width of</param>
        /// <returns>The width of the level.</returns>
        public int GetMapWidth(Entity entity)
        {
            try
            {
                return entity.GetComponent<Map>().Width;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns the height of the specified level. Returns -1 if entity is not a level.
        /// </summary>
        /// <param name="entity">The level to retrieve the height of</param>
        /// <returns>The height of the level.</returns>
        public int GetMapHeight(Entity entity)
        {
            try
            {
                return entity.GetComponent<Map>().Height;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Sets the background of the level.
        /// </summary>
        /// <param name="fileName">The graphic file name to load.</param>
        /// <param name="x">The X position to place the image.</param>
        /// <param name="y">The Y position to place the image.</param>
        public void SetBackground(string fileName, int x = 0, int y = 0)
        {
            _entityFactory.Create<Background>(fileName, x, y);
        }
    }
}
