using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.Systems;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Entities;

namespace MMXEngine.Windows.Shared
{
    public class LevelLoader: ILevelLoader
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IScriptManager _scriptManager;

        public LevelLoader(IEntityFactory entityFactory,
            IScriptManager scriptManager)
        {
            _entityFactory = entityFactory;
            _scriptManager = scriptManager;
        }

        public void Load(string mapName)
        {
            Entity level = _entityFactory.Create<Level>(mapName);
            _entityFactory.Create<Player>(CharacterType.X, 16, -30);

            Script script = level.GetComponent<Script>();
            _scriptManager.QueueScript(script.FilePath, level, "OnLoad");


        }
    }
}
