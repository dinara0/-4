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
        public class Figure
        {
            public int x, y;//координаты 
            public Color color = Color.Black; //Установка цвета по умолчанию
            public bool Is_Drawn = true; //Проверка на отрисовку окружности на панели
        }
        public class Circle : Figure
        {
            public int R = 50; //Задаем постоянный радиус
            
           

            //Конструктор по умолчанию
            public Circle()
            {
                x = 0;
                y = 0;
            }

            //Конструктор с параметрами
            public Circle(int x, int y, Color color)
            {
                this.x = x - R;
                this.y = y - R;
                this.color = color;
            }

            //Деструктор
            ~Circle() { }
        }


        public class Square : Figure
        {
            public int A = 100; //Задаем постоянный радиус



            //Конструктор по умолчанию
            public Square()
            {
                x = 0;
                y = 0;
            }

            //Конструктор с параметрами
            public Square(int x, int y, Color color)
            {
                this.x = x - A/2;
                this.y = y - A/2;
                this.color = color;
            }

            //Деструктор
            ~Square() { }
        }
        public class Triangle : Figure
        {
            public int H = 100; //Расстояние от центра до вершин



            //Конструктор по умолчанию
            public Triangle()
            {
                x = 0;
                y = 0;
            }

            //Конструктор с параметрами
            public Triangle(int x, int y, Color color)
            {
                this.x = x ;
                this.y = y ;
                this.color = color;
            }

            //Деструктор
            ~Triangle() { }
        }


        class Array
        {
            public Figure[] objects; // указатель на указатель объекта 
            private int maxsize = 0;//размер массива максимальный
            private int size = 0; // размер массива
            public Array(int size)
            {// конструктор 
                maxsize = size;
                objects = new Circle[maxsize];// создаю массив из объектов
                for (int i = 0; i < maxsize; ++i)
                    objects[i] = null;

            }



            public void set_value(ref Figure value)//добавление объекта в хранилище
            {
                objects[size] = value;//добавляем объект в свободную ячейку
                size++;
                return;
            }


            public Figure get_value(int i)
            {
                return objects[i];//возвращаем объект по индексу
            }
            public int get_count()
            {
                return size;//возвращаем нынешний размер массива
            }
            public void delete_value(int index)
            {
                if (index < 0 || index >= size)
                {//если выходим за нынешний размер массива

                    return;
                }
                for (int i = index + 1, j = index; i < this.size; i++, j++)
                {
                    objects[j] = objects[i];//смещаем элементы, "затирая" элемент по индексу
                }
                this.size--;
            }

            public bool Empty(int CountElem)
            {
                if (objects[CountElem] == null)
                    return true;
                else return false;
            }
        };

    }
}