using Artemis.Interface;
using Autofac;
using MMXEngine.Contracts.Factories;

namespace MMXEngine.Windows.Shared.Factories
{
    public class ComponentFactory : IComponentFactory
    {
        private readonly IComponentContext _context;

        public ComponentFactory(IComponentContext context)
        {
            _context = context;
        }

        public T Create<T>()
            where T: IComponent
        {
            return (T) _context.ResolveNamed<IComponent>(typeof (T).ToString());
        }
    }
}
