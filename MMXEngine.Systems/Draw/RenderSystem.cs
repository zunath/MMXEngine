﻿using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Draw
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class RenderSystem: EntityProcessingSystem
    {
        private readonly SpriteBatch _spriteBatch;

        public RenderSystem(SpriteBatch spriteBatch) 
            : base(Aspect.All(typeof(Renderable)))
        {
            _spriteBatch = spriteBatch;
        }

        public override void Process(Entity entity)
        {
            Renderable renderable = entity.GetComponent<Renderable>();
            _spriteBatch.Draw(renderable.Texture, renderable.Position, renderable.Source, Color.White);
        }
    }
}
