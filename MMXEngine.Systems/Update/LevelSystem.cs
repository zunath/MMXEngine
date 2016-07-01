using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework.Content;
using MMXEngine.Common.Attributes;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Factories;

namespace MMXEngine.Systems.Update
{
    [LoadableSystem(2)]
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class LevelSystem : EntityProcessingSystem
    {
        private readonly ContentManager _contentManager;
        private readonly IComponentFactory _componentFactory;

        public LevelSystem(ContentManager contentManager, IComponentFactory componentFactory)
            : base(Aspect.All(typeof(Map)))
        {
            _contentManager = contentManager;
            _componentFactory = componentFactory;
        }

        public override void Process(Entity entity)
        {
        }

    }
}
