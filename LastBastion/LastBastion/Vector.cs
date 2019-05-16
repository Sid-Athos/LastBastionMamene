using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Vectors
    {
        float _posX;
        float _posY;

        public Vectors(float x, float y)
        {
            _posX = x;
            _posY = y;
        }

        public float X
        {
            get { return _posX; }
            set { _posX = value; }
        }

        public float Y
        {
            get { return _posY; }
            set { _posY = value; }
        }


        public Vectors CalcNorm(float x, float y)
        {
            float posX = Math.Abs(x - _posX);
            float posY = Math.Abs(y - _posY);

            return new Vectors(posX, posY);
        }

        public float Magnitude()
        {

            return (float)Math.Sqrt((Math.Pow(_posX,2) + (Math.Pow(_posY, 2))));
        }

        public Vectors Substract(Vectors origin, Vectors arrival,float range)
        {
            float x= Math.Abs((origin._posX) - Math.Abs(arrival._posX - range));
            float y = Math.Abs((origin._posY) - Math.Abs(arrival._posY - range));
            return new Vectors(x, y);
        }

        public Vectors AddVecs(Vectors origin, Vectors arrival)
        {
            float x = origin._posX + arrival._posX;
            float y = origin._posY + arrival._posY;
            return new Vectors(x, y);
        }

        public Vectors Normalize(Vectors v)
        {
            float x = v._posX / v.Magnitude();
            float y = v._posY / v.Magnitude();

            return new Vectors(x, y);
        }

       public Vectors Movement(Vectors origin, Vectors arrival, uint timestamp,float speed,float range)
        {
            Vectors moveVec = Substract(origin, arrival,range);
            Vectors normalizedVec =  Normalize(moveVec);
            Console.WriteLine("[{0},{1}]",normalizedVec.X, normalizedVec.Y);
            return normalizedVec;
        }
    }
}
