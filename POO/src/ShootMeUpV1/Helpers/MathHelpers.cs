using System;
using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public static class MathHelpers
    {
        // Vector to angle in radians
        public static float ToAngle(this Vector2 vector) => (float)Math.Atan2(vector.Y, vector.X);

        public static bool IsInRange(this float value, float min, float max) => value >= min && value <= max;

        public static Vector2 GetDirectionTo(this Vector2 from, Vector2 to) => to - from != Vector2.Zero ? Vector2.Normalize(to - from) : Vector2.Zero;
    }
}
