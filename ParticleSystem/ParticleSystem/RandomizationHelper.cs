using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ParticleSystem
{
    public static class RandomizationHelper
    {
        public static double GetNextDouble(
         this Random random,
         double minValue,
         double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static Color GetRandomColor(this Random random)
        {
            int randR = random.Next(0, 255);
            int randG = random.Next(0, 255);
            int randB = random.Next(0, 255);
            return Color.FromArgb(randR, randG, randB);
        }

        public static Vector GetRandomVector(
            this Random random,
            Vector minimum,
            Vector maximum
            )
        {
            return new Vector((float)random.GetNextDouble(minimum.X, maximum.X), (float)random.GetNextDouble(minimum.Y, maximum.Y), (float)random.GetNextDouble(minimum.Z, maximum.Z));
        }
    }
}
