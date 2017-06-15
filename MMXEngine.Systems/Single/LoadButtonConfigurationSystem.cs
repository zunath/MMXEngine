using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Contracts.Components;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Single
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class LoadButtonConfigurationSystem: EntitySystem
    {
        private readonly IInputManager _inputManager;
        private readonly IDataManager _dataManager;
        private bool _isLoaded;

        public LoadButtonConfigurationSystem(IInputManager inputManager, IDataManager dataManager)
        {
            _dataManager = dataManager;
            _inputManager = inputManager;
        }

        public override void Process()
        {
            if (_isLoaded) return;
            IButtonConfiguration configuration = _dataManager.Load<ButtonConfiguration>("./ButtonConfiguration.json");
            _inputManager.SetConfiguration(configuration);
            _isLoaded = true;
        }
    }
}
