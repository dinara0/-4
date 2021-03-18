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
            public CCircle[] objects; // указатель на указатель объекта 
            int maxsize = 100;//размер массива максимальный
            int size = 0; // размер массива
            public	Array(int size)
            {// конструктор 
           // maxsize = size;
           // this.size = maxsize;
            objects = new CCircle[maxsize];// создаю массив из объектов
                for (int i = 0; i < maxsize; ++i)
                    objects[i] = null;

            }
            public void set_value(int i, ref CCircle value)//добавление объекта в хранилище
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
        public int get_count()
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

         public bool Empty(int CountElem)
        {
            if (objects[CountElem] == null)
                return true;
            else return false;
        }



            //Деструктор
            ~Array() { }
        


    };


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
        Array storage = new Array(amtCells);

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //Если объект существует и окрашен в цвет выбранных объектов,то происходит..
                if (storage.get_count() != 0)
                    for (int i = 0; i < amtCells; ++i)
                        if (storage.Empty(i) == false && storage.objects[i].color == Color.Red)
                            storage.delete_value(i); //удаление объекта из хранилища
                Clear_button_Click(sender, e); //Очищение панели
                ShowCircle_button_Click(sender, e); //Показ объектов хранилища

            }

        }
        private void DrawingCircles(ref Array storage, int CountElem)
        {
            //Если ячейка хранилища не пуста, то..
            if (storage.objects[CountElem] != null)
            {
                //создаем ручку, отрисовываем окружность с указанными параметрами
                Pen pen = new Pen(storage.objects[CountElem].color, 3);
                panel1.CreateGraphics().DrawEllipse(pen, storage.objects[CountElem].x,
                    storage.objects[CountElem].y, storage.objects[CountElem].R * 2, storage.objects[CountElem].R * 2);
            }
        }

        //Функция, убирающая выделение объектов
        private void SelectionRemove(ref Array storage)
        {
            for (int i = 0; i < amtCells; ++i)
                //Если хранилище не пусто, то происходит..
                if (!storage.Empty(i))
                {
                    storage.objects[i].color = DefaultBackColor; //установка стандартного цвета
                    if (storage.objects[i].Is_Drawn == true)
                        DrawingCircles(ref storage, i); //перерисовка окружности
                }
        }


        //Функция, возвращающая индекс объекта
        private int CheckCircle(ref Array storage, int Size, int x, int y)
        {
            if (storage.get_count() >=Size)
            {
                for (int i = 0; i < Size; ++i)
                    if (storage.get_count() != 0) //Если хранилище не пусто
                    {
                        if (Math.Sqrt(Math.Pow((x - storage.objects[i].x), 2) + Math.Pow((y - storage.objects[i].y), 2)) <= storage.objects[i].R)
                            return i;
                    }
            }
            return -1;
        }

        //Функция обработки события нажатия курсора на панель
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //Создается объект класса CCircle
            CCircle circle = new CCircle(e.X, e.Y, DefaultBackColor);

            //Получение индекса объекта
            int SellectedItem = CheckCircle(ref storage, amtCells, circle.x, circle.y);
            if (SellectedItem != -1)
            {
                //Если нажат ctrl, выделяем несколько объектов
                if (Control.ModifierKeys == Keys.Control)
                {
                    int x = e.X - circle.R;
                    int y = e.Y - circle.R;
                    for (int i = 0; i < amtCells; ++i)
                        if (!storage.Empty(i))
                        {
                            //проверка условия
                            if (Math.Sqrt(Math.Pow((x - storage.objects[i].x), 2) + Math.Pow((y - storage.objects[i].y), 2)) <= storage.objects[i].R)
                            {
                                storage.objects[i].color = Color.Red; //установка цвета выделенного объекта
                                DrawingCircles(ref storage, i); //перерисовка окружности
                            }
                        }
                }
                else
                {
                    //Иначе выделяем 1 объект и снимаем выделение у остальных объектов хранилища
                    int x = e.X - circle.R;
                    int y = e.Y - circle.R;
                    SelectionRemove(ref storage);
                    for (int i = 0; i < amtCells; ++i)
                        if (!storage.Empty(i))
                        {
                            if (Math.Sqrt(Math.Pow((x - storage.objects[i].x), 2) + Math.Pow((y - storage.objects[i].y), 2)) <= storage.objects[i].R)
                            {
                                storage.objects[i].color = Color.Red; //установка цвета выделенного объекта
                                DrawingCircles(ref storage, i); //перерисовка окружности
                                break;
                            }
                        }
                    //Перерисовываем окружность
                    storage.objects[SellectedItem].color = Color.Red;
                    DrawingCircles(ref storage, SellectedItem);
                }
                return;
            }
            //Добавляем окружность в хранилище
            storage.set_value(CountElem, ref circle);

            //Снимаем выделение всех объектов хранилища
            SelectionRemove(ref storage);

            //Устанавливаем цвет выделяемого объекта на новый добавленный
            storage.objects[item].color = Color.Red;

            //Отрисовываем окружность
            DrawingCircles(ref storage, item);

            //Увеличиваем счетчик количества объектов хранилища
            ++CountElem;
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            panel1.Refresh(); //перерисовка
            for (int i = 0; i < amtCells; ++i)
                if (!storage.Empty(i))
                {
                    storage.objects[i].Is_Drawn = false;
                    storage.objects[i].color = DefaultBackColor;
                }

        }
        //Обработчик события Click кнопки "Показать объекты хранилища" 
        private void ShowCircle_button_Click(object sender, EventArgs e)
        {
            //Сначала очищается панель
           panel1.Refresh();

            //Если хранилище не пустое, то..
            if (storage.get_count() != 0)
                for (int i = 0; i < amtCells; ++i)
                {
                    DrawingCircles(ref storage, i); //рисуется окружность,
                    if (!storage.Empty(i))
                        storage.objects[i].Is_Drawn = true; //устанавливается флаг(объект отрисован)
                }

        }






    }
}
