﻿using Microsoft.Xna.Framework;

namespace MMXEngine.Interfaces.Managers
{
    public interface ICameraManager
    {
        float Zoom { get; set; }
        float Rotation { get; set; }
        Vector2 Position { get; set; }
        Matrix Transform { get; }
        Matrix InverseTransform { get; }
        
        void Update();
    }
}
