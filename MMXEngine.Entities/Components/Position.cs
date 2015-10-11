﻿using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Position : IComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
