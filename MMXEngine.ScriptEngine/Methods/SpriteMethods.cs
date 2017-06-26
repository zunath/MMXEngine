using Artemis;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.ECS.Components;

namespace MMXEngine.ScriptEngine.Methods
{
    /// <summary>
    /// Script methods used for sprite manipulation.
    /// </summary>
    [ScriptNamespace("Sprite")]
    public class SpriteMethods: ISpriteMethods
    {
        /// <summary>
        /// Sets the color palette of a sprite to a custom value.
        /// </summary>
        /// <param name="entity">The entity to manipulate.</param>
        /// <param name="red">The amount of red to set.</param>
        /// <param name="green">The amount of green to set.</param>
        /// <param name="blue">The amount of blue to set.</param>
        /// <param name="alpha">The amount of alpha (transparency) to set.</param>
        public void SetColorPaletteCustom(Entity entity, int red, int green, int blue, int alpha)
        {
            if (entity.HasComponent<Sprite>())
            {
                entity.GetComponent<Sprite>().SetColorOverride(red, green, blue, alpha);
            }
        }

        /// <summary>
        /// Sets the color palette of a sprite to a pre-defined value.
        /// </summary>
        /// <param name="entity">The entity to manipulate.</param>
        /// <param name="color">The pre-defined color to use.</param>
        public void SetColorPalette(Entity entity, ColorType color)
        {
            if (entity.HasComponent<Sprite>())
            {
                ColorTypeAttribute attr = color.GetAttributeOfType<ColorTypeAttribute>();
                entity.GetComponent<Sprite>().SetColorOverride(attr.Red, attr.Green, attr.Blue, attr.Alpha);
            }
        }

        /// <summary>
        /// Removes a custom color palette from an entity.
        /// </summary>
        /// <param name="entity">The entity to reset.</param>
        public void ResetColorPalette(Entity entity)
        {
            if (entity.HasComponent<Sprite>())
            {
                entity.GetComponent<Sprite>().RemoveColorOverride();
            }
        }
    }
}
