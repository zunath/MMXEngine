using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Windows.Factories
{
    public static class GameFactory
    {
        private static IGameManager _gameManager;

        public static IGameManager GetGameManager()
        {
            return _gameManager ?? (_gameManager = IOCContainer.Resolve<IGameManager>());
        }
    }
}
