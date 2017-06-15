using Autofac;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.States;

namespace MMXEngine.Windows.Factories
{
    public class PlayerStateFactory: IPlayerStateFactory
    {
        private readonly IComponentContext _context;

        public PlayerStateFactory(IComponentContext context)
        {
            _context = context;
        }
        public T Create<T>() 
            where T : IPlayerState
        {
            return (T)_context.ResolveNamed<IPlayerState>(typeof(T).ToString());
        }
    }
}
