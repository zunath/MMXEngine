﻿using System;
using Microsoft.Xna.Framework;

namespace MMXEngine.Common.Extensions
{
    public static class RectangleExtensions
    {
        /// <summary>
        /// Calculates the signed depth of intersection between two rectangles.
        /// </summary>
        /// <returns>
        /// The amount of overlap between two intersecting rectangles. These
        /// depth values can be negative depending on which wides the rectangles
        /// intersect. This allows callers to determine the correct direction
        /// to push objects in order to resolve collisions.
        /// If the rectangles are not intersecting, Vector2.Zero is returned.
        /// </returns>
        public static Vector2 GetIntersectionDepth(this Rectangle rectA, Rectangle rectB)
        {
            // Calculate half sizes.
            float halfWidthA = rectA.Width / 2.0f;
            float halfHeightA = rectA.Height / 2.0f;
            float halfWidthB = rectB.Width / 2.0f;
            float halfHeightB = rectB.Height / 2.0f;

            // Calculate centers.
            Vector2 centerA = new Vector2(rectA.Left + halfWidthA, rectA.Top + halfHeightA);
            Vector2 centerB = new Vector2(rectB.Left + halfWidthB, rectB.Top + halfHeightB);

            // Calculate current and minimum-non-intersecting distances between centers.
            float distanceX = centerA.X - centerB.X;
            float distanceY = centerA.Y - centerB.Y;
            float minDistanceX = halfWidthA + halfWidthB;
            float minDistanceY = halfHeightA + halfHeightB;

            // If we are not intersecting at all, return (0, 0).
            if (Math.Abs(distanceX) >= minDistanceX || Math.Abs(distanceY) >= minDistanceY)
                return Vector2.Zero;

            // Calculate and return intersection depths.
            float depthX = distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
            float depthY = distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
            return new Vector2(depthX, depthY);
        }

        /// <summary>
        /// Gets the position of the center of the bottom edge of the rectangle.
        /// </summary>
        public static Vector2 GetBottomCenter(this Rectangle rect)
        {
            return new Vector2(rect.X + rect.Width / 2.0f, rect.Bottom);
        }

        public static Vector4 GetCorrectionVector(this Rectangle rect, Rectangle target)
        {
            Vector4 vector = new Vector4();

            float x1 = Math.Abs(rect.Right - target.Left);
            float x2 = Math.Abs(rect.Left - target.Right);
            float y1 = Math.Abs(rect.Bottom - target.Top);
            float y2 = Math.Abs(rect.Top - target.Bottom);


            if (x1 < x2)
            {
                vector.X = x1;
                // vector.DirectionX = Left
            }
            else if (x1 > x2)
            {
                vector.X = x2;
                // vector.DirectionX = Right;
            }

            if (y1 < y2)
            {
                vector.Y = y1;
                // vector.directionY = Up
            }
            else if (y1 > y2)
            {
                vector.Y = y2;
                // vector.DirectionY = Down
            }
            
            return vector;
        }

    }
}
