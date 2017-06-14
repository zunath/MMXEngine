﻿using Artemis;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.ScriptEngine.Methods
{
    public class SpriteMethods: IScriptMethodGroup
    {
        public static void SetColorPaletteCustom(Entity entity, int red, int green, int blue, int alpha)
        {
            if (entity.HasComponent<Sprite>())
            {
                entity.GetComponent<Sprite>().SetColorOverride(red, green, blue, alpha);
            }
        }

        public static void SetColorPalette(Entity entity, ColorType color)
        {
            if (entity.HasComponent<Sprite>())
            {
                ColorTypeAttribute attr = color.GetAttributeOfType<ColorTypeAttribute>();
                entity.GetComponent<Sprite>().SetColorOverride(attr.Red, attr.Green, attr.Blue, attr.Alpha);
            }
        }

        public static void ResetColorPalette(Entity entity)
        {
            if (entity.HasComponent<Sprite>())
            {
                entity.GetComponent<Sprite>().RemoveColorOverride();
            }
        }
    }
}