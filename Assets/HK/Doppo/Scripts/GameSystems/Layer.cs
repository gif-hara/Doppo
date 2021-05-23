using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Doppo
{
    /// <summary>
    /// 
    /// </summary>
    public static class Layer
    {
        public static class Index
        {
            public const int Default = 0;
            public const int TransparentFX = 1;
            public const int IgnoreRaycast = 2;
            public const int Water = 3;
            public const int UI = 5;
            public const int Player = 6;
            public const int Player_Bullet = 7;
            public const int Enemy = 8;
            public const int Enemy_Bullet = 9;
            public const int Stage = 10;
        }

        public static class Flag
        {
            public const int Default = 1 << 0;
            public const int TransparentFX = 1 << 1;
            public const int IgnoreRaycast = 1 << 2;
            public const int Water = 1 << 3;
            public const int UI = 1 << 5;
            public const int Player = 1 << 6;
            public const int Player_Bullet = 1 << 7;
            public const int Enemy = 1 << 8;
            public const int Enemy_Bullet = 1 << 9;
            public const int Stage = 1 << 10;
        }

    }
}
