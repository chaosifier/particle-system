using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ParticleSystem
{
    public class Particle
    {
        private Vector _position;
        public Vector Position
        {
            get { return _position; }
        }

        private Vector _velocity;
        public Vector Velocity
        {
            get { return _velocity; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
        }

        private int _size;
        public int Size
        {
            get { return _size; }
        }

        private Color _color;
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Particle() : this(Vector.Zero, Vector.Zero, Color.Orange, 0)
        {

        }

        public Particle(Vector position, Vector velocity, Color color, int age, int size = 5)
        {
            _position = position;
            _velocity = velocity;
            _color = color;
            _size = size;

            if (age > 0)
                _age = age;
        }

        public void Update(bool ignoreAge = false)
        {
            _velocity = _velocity - Environment.GetInstance().Gravity + Environment.GetInstance().Wind;
            _position = _position + _velocity;

            if (!ignoreAge)
                _age++;
        }
    }
}
