﻿using Artemis;
using Artemis.System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.Entities
{

    public class Background: IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly ContentManager _content;

        public Background(IComponentFactory componentFactory,
            ContentManager content)
        {
            _componentFactory = componentFactory;
            _content = content;
        }

        public void BuildEntity(Entity entity, params object[] args)
        {
            string textureFile = args[0] as string;
            int? x = args[1] as int?;
            int? y = args[2] as int?;

            string filePath = ".\\Graphics\\Backgrounds\\" + textureFile;

            StaticGraphic staticGraphic = _componentFactory.Create<StaticGraphic>();
            staticGraphic.Scrolls = true;
            staticGraphic.Texture = _content.Load<Texture2D>(filePath);
            entity.AddComponent(staticGraphic);
            
            Position position = _componentFactory.Create<Position>();
            position.X = x ?? 0; 
            position.Y = y ?? 0; 
            entity.AddComponent(position);

            Entity existingBackground = EntitySystem.BlackBoard.GetEntry<Entity>("Background");
            existingBackground?.Delete();

            EntitySystem.BlackBoard.SetEntry("Background", entity);
        }
    }
}