using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp9
{
     class Controller
    {
        private double k, b; 
        private Form1 form; //reference to the form
        private int x, y; //coordinates of the point

        public Controller(Form1 form1)
        {
            form = form1;
        }

        public void GetLinesCoordinates()
        {
            Model.pointStruct p1 = Model.points[0];
            Model.pointStruct p2 = Model.points[1];
            Model.pointStruct p3 = Model.points[2];

            k = (double)(p2.y - p1.y) / (p2.x - p1.x);
            b = p3.y - k * p3.x;

            Model.coefsTrianglesSides[0] = new Model.coefsTrianglesSide(k, b);

            k = (double)(p3.y - p2.y) / (p3.x - p2.x);
            b = p1.y - k * p1.x;

            Model.coefsTrianglesSides[1] = new Model.coefsTrianglesSide(k, b);

            k = (double)(p3.y - p1.y) / (p3.x - p1.x);
            b = p2.y - k * p2.x;

            Model.coefsTrianglesSides[2] = new Model.coefsTrianglesSide(k, b);

            //calculate points of crossing sides 
            x = (int)((Model.coefsTrianglesSides[1].b - Model.coefsTrianglesSides[0].b) / (Model.coefsTrianglesSides[0].k - Model.coefsTrianglesSides[1].k));
            y = (int)(Model.coefsTrianglesSides[1].k * x + Model.coefsTrianglesSides[1].b);
            Model.pointsTrianglesSides[0] = new Model.pointsTrianglesSide(x, y);

            x = (int)((Model.coefsTrianglesSides[2].b - Model.coefsTrianglesSides[1].b) / (Model.coefsTrianglesSides[1].k - Model.coefsTrianglesSides[2].k));
            y = (int)(Model.coefsTrianglesSides[2].k * x + Model.coefsTrianglesSides[2].b);
            Model.pointsTrianglesSides[1] = new Model.pointsTrianglesSide(x, y);

            //draw 1st side of the triangle
            form.DrawTriangleLine(new Point(Model.pointsTrianglesSides[0].x, Model.pointsTrianglesSides[0].y), 
                                                     new Point(Model.pointsTrianglesSides[1].x, Model.pointsTrianglesSides[1].y), 
                                                     Color.Red);

            x = (int)((Model.coefsTrianglesSides[2].b - Model.coefsTrianglesSides[0].b) / (Model.coefsTrianglesSides[0].k - Model.coefsTrianglesSides[2].k));
            y = (int)(Model.coefsTrianglesSides[2].k * x + Model.coefsTrianglesSides[2].b);
            Model.pointsTrianglesSides[2] = new Model.pointsTrianglesSide(x, y);

            //draw other sides of the triangle
            form.DrawTriangleLine(new Point(Model.pointsTrianglesSides[1].x, Model.pointsTrianglesSides[1].y),
                                                     new Point(Model.pointsTrianglesSides[2].x, Model.pointsTrianglesSides[2].y),
                                                     Color.Green);

            form.DrawTriangleLine(new Point(Model.pointsTrianglesSides[0].x, Model.pointsTrianglesSides[0].y),
                                                     new Point(Model.pointsTrianglesSides[2].x, Model.pointsTrianglesSides[2].y),
                                                     Color.Green);
        }
    }
}
