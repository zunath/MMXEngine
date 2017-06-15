using Artemis;
using MMXEngine.Common.Enumerations;

namespace MMXEngine.Contracts.ScriptMethods
{
    public interface ISpriteMethods
    {
        void SetColorPaletteCustom(Entity entity, int red, int green, int blue, int alpha);
        void SetColorPalette(Entity entity, ColorType color);
        void ResetColorPalette(Entity entity);
    }
}
