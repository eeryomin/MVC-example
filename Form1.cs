using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        Graphics g = null; 
        byte count = 0;  
        Controller controller;

        public Form1()
        {
            InitializeComponent();
            
        }

        public void DrawTriangleLine(Point p1, Point p2, Color color)
        {
            g.DrawLine(new Pen(color, 3), p1, p2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();

            controller = new Controller(this); 
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
                if (count == 3) return; 

                g.FillEllipse(new SolidBrush(Color.Black), e.X, e.Y, 7, 7); 

                Model.points[count] = new Model.pointStruct(e.X, e.Y);

                if (count == 2) 
                {
                    controller.GetLinesCoordinates();
                }
               
                count++;                         
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (g != null)
            {
                count = 0;
                Model.points = new Model.pointStruct[3];
                g.Clear(Color.White);
            }
        }
    }
}
