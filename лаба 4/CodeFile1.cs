using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лаба_4
{
    public partial class Form1 : Form
    {
        private void DrawingCircles(ref Array storage, int index)
        {
            //Если ячейка хранилища не пуста, то..
            if (storage.objects[index] != null)
            {
                //создаем ручку, отрисовываем окружность с указанными параметрами
                Pen pen = new Pen(storage.objects[index].color, 3);
                panel1.CreateGraphics().DrawEllipse(pen, storage.objects[index].x,
                    storage.objects[index].y, ((Circle)storage.objects[index]).R * 2, ((Circle)storage.objects[index]).R * 2);
            }
        }
        private void DrawingSquare(ref Array storage, int index)
        {
            //Если ячейка хранилища не пуста, то..
            if (storage.objects[index] != null)
            {
                //создаем ручку, отрисовываем окружность с указанными параметрами
                Pen pen = new Pen(storage.objects[index].color, 3);
               panel1.CreateGraphics().DrawRectangle(pen, 0, 0, 50, 50);
            }
        }
        private void DrawingTriangle(ref Array storage, int index)
        {
            //Если ячейка хранилища не пуста, то..
            if (storage.objects[index] != null)
            {
                //создаем ручку, отрисовываем окружность с указанными параметрами
                Pen pen = new Pen(storage.objects[index].color, 3);
                //создаем три вершины треугольника
                Point[] points = new Point[3];
                points[0].X = 10; points[0].Y = 10;
                points[1].X = 100; points[1].Y = 200;
                points[2].X = 30; points[2].Y = 150;
                panel1.CreateGraphics().DrawPolygon(pen, points);
            }
        }
    }
}