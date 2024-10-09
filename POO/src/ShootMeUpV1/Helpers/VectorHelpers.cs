using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShootMeUpV1
{
    public static class VectorHelpers
    {
        // Vector to angle in radians
        public static float ToAngle(this Vector2 vector) => (float)Math.Atan2(vector.Y, vector.X);
    }
}
