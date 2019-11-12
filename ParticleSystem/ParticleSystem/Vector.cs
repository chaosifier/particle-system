using System;
using System.Collections.Generic;
using System.Text;

namespace ParticleSystem
{
    public class Vector
    {
        private float _xCoordinate;
        public float X
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }

        private float _yCoordinate;
        public float Y
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        private float _zCoordinate;
        public float Z
        {
            get { return _zCoordinate; }
            set { _zCoordinate = value; }
        }

        public Vector()
        {

        }

        public Vector(float x, float y, float z)
        {
            _xCoordinate = x;
            _yCoordinate = y;
            _zCoordinate = z;
        }

        public static Vector Add(Vector operand1, Vector operand2)
        {
            if (operand1 == null || operand2 == null) return null;

            return new Vector(operand1.X + operand2.X, operand1.Y + operand2.Y, operand1.Z + operand2.Z);
        }

        public static Vector Subtract(Vector operand1, Vector operand2)
        {
            if (operand1 == null || operand2 == null) return null;

            return new Vector(operand1.X - operand2.X, operand1.Y - operand2.Y, operand1.Z - operand2.Z);
        }

        public static Vector Multiply(Vector operand1, float operand2)
        {
            if (operand1 == null) return null;

            return new Vector(operand1.X * operand2, operand1.Y * operand2, operand1.Z * operand2);
        }

        public static Vector Negate(Vector operand1)
        {
            if (operand1 == null) return null;

            return new Vector(-operand1.X, -operand1.Y, -operand1.Z);
        }

        //public static bool operator ==(Vector operand1, Vector operand2)
        //{
        //    if (operand1 == null || operand2 == null) return false;

        //    return operand1.X.Equals(operand2.X) && operand1.Y.Equals(operand2.Y) && operand1.Z.Equals(operand2.Z);
        //}

        //public static bool operator !=(Vector operand1, Vector operand2)
        //{
        //    if (operand1 == null || operand2 == null) return false;

        //    return operand1.X != operand2.X && operand1.Y != operand2.Y && operand1.Z != operand2.Z;
        //}

        public static Vector operator +(Vector operand1, Vector operand2)
        {
            return Add(operand1, operand2);
        }

        public static Vector operator -(Vector operand1, Vector operand2)
        {
            return Subtract(operand1, operand2);
        }

        public static Vector operator *(Vector operand1, float operand2)
        {
            return Multiply(operand1, operand2);
        }

        public static Vector operator *(float operand1, Vector operand2)
        {
            return Multiply(operand2, operand1);
        }

        public static Vector Zero
        {
            get
            {
                return new Vector(0f, 0f, 0f);
            }
        }

        public override bool Equals(object obj)
        {
            var operand2 = obj as Vector;
            return this == operand2;
        }

        public override string ToString()
        {
            return $"{_xCoordinate}, {_yCoordinate}, {_zCoordinate}";
        }

        public override int GetHashCode()
        {
            return _xCoordinate.GetHashCode() ^ _yCoordinate.GetHashCode() ^ _zCoordinate.GetHashCode();
        }
    }
}
