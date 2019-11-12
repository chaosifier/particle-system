using System;
using System.Collections.Generic;
using System.Text;

namespace ParticleSystem
{
    public class Environment
    {
        private static Environment _instance = new Environment();

        private Vector _gravity = Vector.Zero;
        public Vector Gravity
        {
            get { return _gravity; }
            set { _gravity = value; }
        }

        private Vector _wind = Vector.Zero;
        public Vector Wind
        {
            get { return _wind; }
            set { _wind = value; }
        }

        public static Environment GetInstance()
        {
            return _instance;
        }
    }
}
