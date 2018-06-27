// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

namespace Leopotam.Ecs.Types {
    public static class TypeHelpers {
        /// <summary>
        /// Degrees to radians conversion multiplier.
        /// </summary>
        public const float Deg2Rad = (float) System.Math.PI / 180f;

        /// <summary>
        /// Radians to degrees conversion multiplier.
        /// </summary>
        public const float Rad2Deg = 1f / Deg2Rad;
    }
}