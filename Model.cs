using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    static class Model
    {       
        public static pointStruct[] points = new pointStruct[3]; 
        public static coefsTrianglesSide[] coefsTrianglesSides = new coefsTrianglesSide[3];
        public static pointsTrianglesSide[] pointsTrianglesSides = new pointsTrianglesSide[3];

        public struct pointStruct 
        {
            public int x, y;

            public pointStruct(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }

        public struct coefsTrianglesSide 
        {
            public double k, b; 

            public coefsTrianglesSide(double p1, double p2) 
            {
                k = p1;
                b = p2;
            }
        }

        public struct pointsTrianglesSide
        {
            public int x, y; 

            public pointsTrianglesSide(int width, int height)
            {
                x = width;
                y = height;
            }
        }
    }
}
