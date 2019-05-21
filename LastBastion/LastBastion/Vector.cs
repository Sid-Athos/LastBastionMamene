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

       public Vectors Movement(Vectors origin, Vectors arrival, uint timestamp,float speed,float range)
        {
            Vectors moveVec = Substract(origin, arrival,range);
            Vectors normalizedVec =  Normalize(moveVec,speed);
             return AddVecs(origin,moveVec,speed);
        }

        public bool IsInRange(Vectors origin, Vectors arrival, float range)
        {
            float result = (float)(Math.Pow(arrival.X - origin.X, 2)+ Math.Pow(arrival.Y - origin.Y, 2));
            return result <= (float)Math.Pow(range,2);
        }

        float SubstractX(Vectors origin, Vectors arrival)
        {
            float x = Math.Abs((origin._posX) - Math.Abs(arrival._posX));
            return x;
        }

        float SubstractY(Vectors origin, Vectors arrival)
        {
            float y = Math.Abs((origin._posY) - Math.Abs(arrival._posY));
            return y;
        }

        float Magnitude()
        {

            return (float)Math.Sqrt((Math.Pow(X,2) + (Math.Pow(Y, 2))));
        }

        internal float Distance(Vectors origin, Vectors arrival)
        {
            return (float)(Math.Pow(arrival.X - origin.X, 2) + Math.Pow(arrival.Y - origin.Y, 2));
        }

        Vectors Substract(Vectors origin, Vectors arrival,float range)
        {
            float x= (arrival._posX) - Math.Abs(origin._posX);
            float y = (arrival._posY) - Math.Abs(origin._posY );
            return new Vectors(x, y);
        }

        Vectors AddVecs(Vectors origin, Vectors arrival,float speed)
        {
            float x = (float)origin.X + ((arrival.X-1.5f)*speed);
            float y = (float)origin.Y + ((arrival.Y-1.5f)*speed);
            return new Vectors(x, y);
        }

        Vectors Normalize(Vectors v,float speed)
        {
            float x = v._posX / v.Magnitude() * speed;

            float y = v._posY / v.Magnitude() * speed;

            return new Vectors(x, y);
        }
     }  
}
