using Microsoft.Xna.Framework;
using MMXEngine.Common.Enumerations;

namespace MMXEngine.Common.Extensions
{
    public static class RectangleExtensions
    {
        public static CollisionType GetCollisionType(this Rectangle objectBounds, Rectangle referenceBounds)
        {
            if (!referenceBounds.Intersects(objectBounds)) return CollisionType.None;
            // Object is above tile
            if (objectBounds.Bottom > referenceBounds.Top && objectBounds.Bottom < referenceBounds.Bottom)
            {
                return CollisionType.Top;
            }
            // Object is below tile
            if (objectBounds.Top < referenceBounds.Bottom && objectBounds.Top > referenceBounds.Top)
            {
                return CollisionType.Bottom;
            }
            // Object is to the left of tile
            if (objectBounds.Left < referenceBounds.Right && objectBounds.Left > referenceBounds.Left)
            {
                return CollisionType.Left;
            }
            // Object is to the right of tile
            if (objectBounds.Right > referenceBounds.Left && objectBounds.Right < referenceBounds.Right)
            {
                return CollisionType.Right;
            }

            return CollisionType.None;
        }
    }
}
