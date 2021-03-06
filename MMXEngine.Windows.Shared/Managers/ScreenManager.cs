﻿using Artemis;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Managers;

namespace MMXEngine.Windows.Shared.Managers
{
    public class ScreenManager : IScreenManager
    {
        private IScreen _screen;
        private readonly EntityWorld _world;

        public ScreenManager(EntityWorld world)
        {
            _world = world;
        }

        public void ChangeScreen(IScreen screen)
        {
            _screen?.Close();
            _world.Clear();

            _screen = screen;
            _screen.Initialize();
        }

        public void Update()
        {
            _screen.Update();
        }

        public void Draw()
        {
            _screen.Draw();
        }
    }
}
