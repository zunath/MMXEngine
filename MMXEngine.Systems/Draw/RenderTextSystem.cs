using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Draw
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class RenderTextSystem: EntityProcessingSystem
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly IContentManager _contentManager;

        public RenderTextSystem(SpriteBatch spriteBatch,
            IContentManager contentManager)
            : base(Aspect.All(typeof(VisibleText),
                typeof(Position)))
        {
            _spriteBatch = spriteBatch;
            _contentManager = contentManager;
        }

        public override void Process(Entity entity)
        {
            VisibleText text = entity.GetComponent<VisibleText>();
            Position position = entity.GetComponent<Position>();
            SpriteFont font = _contentManager.Load<SpriteFont>("./Fonts/Arial");
            
            _spriteBatch.DrawString(font, 
                text.Message, 
                new Vector2(position.X, position.Y),
                Color.Black,
                0,
                Vector2.Zero,
                0.5f,
                SpriteEffects.None,
                0.0f);

        }
    }
}
