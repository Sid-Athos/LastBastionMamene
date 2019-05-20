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

        public float SubstractX(Vectors origin, Vectors arrival)
        {
            float x = Math.Abs((origin._posX) - Math.Abs(arrival._posX));
            return x;
        }

        public float SubstractY(Vectors origin, Vectors arrival)
        {
            float y = Math.Abs((origin._posY) - Math.Abs(arrival._posY));
            return y;
        }

        public float Magnitude()
        {

            return (float)Math.Sqrt((Math.Pow(X,2) + (Math.Pow(Y, 2))));
        }

        public Vectors Substract(Vectors origin, Vectors arrival,float range)
        {
            float x= Math.Abs((arrival._posX) - Math.Abs(origin._posX));
            float y = Math.Abs((arrival._posY) - Math.Abs(origin._posY ));
            return new Vectors(x, y);
        }


        public Vectors AddVecs(Vectors origin, Vectors arrival)
        {
            float x = (float)origin._posX + (arrival._posX*0.2f);
            float y = (float)origin._posY + (arrival._posY*0.2f);
            return new Vectors(x, y);
        }

        public Vectors Normalize(Vectors v,float speed)
        {
            float x = v._posX / v.Magnitude() * speed;

            float y = v._posY / v.Magnitude() * speed;

            return new Vectors(x, y);
        }

       public Vectors Movement(Vectors origin, Vectors arrival, uint timestamp,float speed,float range)
        {
            Vectors moveVec = Substract(origin, arrival,range);
            Vectors normalizedVec =  Normalize(moveVec,speed);
            return AddVecs(origin,moveVec);
        }

        public bool IsInRange(Vectors origin, Vectors arrival, float range)
        {
            float result = (float)(Math.Pow(arrival.X - origin.X, 2)+ Math.Pow(arrival.Y - origin.Y, 2));
            return result <= (float)Math.Pow(range,2);
        }

        public float Distance(Vectors origin, Vectors arrival)
        {
            return (float)(Math.Pow(arrival.X - origin.X, 2) + Math.Pow(arrival.Y - origin.Y, 2));
        }
    }
}
