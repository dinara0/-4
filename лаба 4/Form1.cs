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
        public Form1()
        {
            InitializeComponent();
        }
        //Функция обработки получения координат XY события передвижения курсора по панели
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class CCircle
        {
            public int R = 75; //Задаем постоянный радиус
            public int x, y;
            public Color color = DefaultBackColor; //Установка цвета по умолчанию
            public bool Is_Drawn = true; //Проверка на отрисовку окружности на панели

            //Конструктор по умолчанию
            public CCircle()
            {
                x = 0;
                y = 0;
            }

            //Конструктор с параметрами
            public CCircle(int x, int y, Color color)
            {
                this.x = x - R;
                this.y = y - R;
                this.color = color;
            }

            //Деструктор
            ~CCircle() { }
        }
    
        class Array  {
        private	CCircle[] objects; // указатель на указатель объекта 
        int maxsize;//размер массива максимальный
        int size; // размер массива
        public	Array(int size)
        {// конструктор 
            maxsize = size;
            this.size = maxsize;
            objects = new CCircle[size];// создаю массив из объектов
                for (int i = 0; i < size; ++i)
                    objects[i] = null;

            }
            public void set_value(int i, CCircle value)//добавление объекта в хранилище
        {
            if (i < 0 || i >= maxsize)
            {// если индекс выходит за размеры массива
              //  printf("Выход за границы массива\n");
                return;
            }
            if (i > size)
            {// если индекс больше нынещнего размера массива, но меньше максимального
                objects[size + 1] = value;//добавляем объект в свободную ячейку
                size++;
                return;
            }
            objects[i] = value;// вставляем элемент вместо другого объекта
        }

        public CCircle get_value(int i)
        {
            return objects[i];//возвращаем объект по индексу
        }
        int get_count()
        {
            return size;//возвращаем нынешний размер массива
        }
        public void delete_value(int index)
        {
            if (index < 0 || index >= size)
            {//если выходим за нынешний размер массива
              //  printf("Выход за границы массива");
                return;
            }
            for (int i = index + 1, j = index; i < this.size; i++, j++)
            {
                objects[j] = objects[i];//смещаем элементы, " затирая" элемент по индексу
            }
           // printf("объект из ячейки %i удален\n", index + 1);
            this.size--;
        }
            //Деструктор
            ~Array() { }
        


    };


        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //Функция обработки получения координат XY события передвижения курсора по панели
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Coord_label.Text = "X: " + e.X + " Y: " + e.Y;
        }
        //Функция обработки события передвижения курсора по форме(очищение метки)
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Coord_label.Text = "";
        }

        //Инициализация необходимых переменных
        static int amtCells = 1;
        int CountElem = 0;
        int item = 0;

    }
}
