using System;
using Autofac;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;

namespace MMXEngine.Windows.Shared.Factories
{
    public class ScreenFactory :IScreenFactory
    {
        private readonly IComponentContext _context;

        public ScreenFactory(IComponentContext context)
        {
            _context = context;
        }

        public IScreen Create<T>() 
            where T : IScreen
        {
            return _context.ResolveNamed<IScreen>(typeof (T).ToString());
        }

        public IScreen Create(Type screenType)
        {
            if(!typeof(IScreen).IsAssignableFrom(screenType))
                throw new Exception("screenType must implement the IScreen interface.");

            return _context.ResolveNamed<IScreen>(screenType.ToString());
        }

    }
}
