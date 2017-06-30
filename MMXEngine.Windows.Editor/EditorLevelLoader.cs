using Artemis;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.Systems;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Entities;

namespace MMXEngine.Windows.Editor
{
    public class EditorLevelLoader: ILevelLoader
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IScriptManager _scriptManager;

        public EditorLevelLoader(IEntityFactory entityFactory,
            IScriptManager scriptManager)
        {
            _entityFactory = entityFactory;
            _scriptManager = scriptManager;
        }

        public void Load(string mapName)
        {
            Entity level = _entityFactory.Create<Level>(mapName);

            Script script = level.GetComponent<Script>();
            _scriptManager.QueueScript(script.FilePath, level, "OnLoad");
        }
    }
}
