﻿using Microsoft.Xna.Framework.Graphics;
using ShootMeUpV1;

namespace Configs
{
    public static class Bullet
    {
        public const float Speed = 500f;
        public const float CollisionRadius = 6f;
        public static readonly Texture2D Texture = Visuals.SwordSlash;
        public const float Scale = 0.065f;
    }

    public static class Enemy
    {
        public const float Speed = 100f;
        public const float CollisionRadius = 75f;
        public static readonly Texture2D Texture = Visuals.BasicOni;
        public const float Scale = 0.25f;
    }

    public static class Player
    {
        public const float BaseSpeed = 300f;
        public const float BaseCollisionRadius = 50f;
        public static readonly Texture2D Texture = Visuals.Player;
        public const float BaseScale = 0.25f;
        public const int BaseDamage = 20;
    }
}