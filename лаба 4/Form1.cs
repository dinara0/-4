﻿using System;
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

       
        //Инициализация необходимых переменных
        Array storage = new Array(100);

       
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


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Delete) return;// если клавиша - delete

            //Если объект существует и окрашен в цвет выбранных объектов,то происходит..
            if (storage.get_count() != 0)
                for (int i = 0; i < storage.get_count(); ++i)
                {
                    if (storage.Empty(i) == false && storage.get_value(i).color == Color.Red)
                    {
                        storage.delete_value(i); //удаление объекта из хранилища
                        i--;
                    }
                }
                Clear_button_Click(sender, e); //Очищение панели
                ShowCircle_button_Click(sender, e); //Показ объектов хранилища

            

        }


        //Функция, убирающая выделение объектов
        private void SelectionRemove(ref Array storage)
        {
            for (int i = 0; i < storage.get_count(); ++i)
                //Если хранилище не пусто, то происходит..
                if (!storage.Empty(i))
                {
                    storage.objects[i].color = Color.Black; //установка стандартного цвета
                    if (storage.objects[i].Is_Drawn == true)
  //!!!!!!!!!!!!
                        DrawingCircles(ref storage, i); //перерисовка окружности
                }
        }


        //Функция, возвращающая индекс объекта
        private int CheckFigure(ref Array storage, int Size, int x, int y)
        {
            if (storage.get_count() != 0) 
            {
                for (int i = 0; i < Size; ++i)
                    if (!storage.Empty(i)) //Если хранилище не пусто
                    {
                        Figure o = storage.get_value(i);
                        if (o.Equals(typeof(Circle)))
                            if (Math.Sqrt(Math.Pow((x - o.x), 2) + Math.Pow((y - o.y), 2)) <= ((Circle)o).R)
                            return i;

                    }
            }
            return -1;
        }

        //Функция обработки события нажатия курсора на панель
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
           // if (button1.Enabled == false)
            //{
                //Создается объект класса CCircle
                Figure figure = new Circle(e.X, e.Y, Color.Black);
            //}
           

            //Получение индекса объекта
            int SellectedItem = CheckFigure(ref storage, storage.get_count(), figure.x, figure.y);
            if (SellectedItem != -1)
            {
                //Если нажат ctrl, выделяем несколько объектов
                if (Control.ModifierKeys == Keys.Control)
                {
                    int x = e.X - ((Circle)figure).R;// присваиваем координаты курсора
                    int y = e.Y - ((Circle)figure).R; 
                    for (int i = 0; i < storage.get_count(); ++i)
                        if (!storage.Empty(i))
                        {
                            //проверка условия
                            if (Math.Sqrt(Math.Pow((x - storage.objects[i].x), 2) + Math.Pow((y - storage.objects[i].y), 2)) <= ((Circle)storage.objects[i]).R)
                            {
                                storage.objects[i].color = Color.Red; //установка цвета выделенного объекта
                                DrawingCircles(ref storage, i); //перерисовка окружности
                            }
                        }
                }
                else
                {
                    //Иначе выделяем 1 объект и снимаем выделение у остальных объектов хранилища
                    int x = e.X - ((Circle)figure).R;
                        int y = e.Y - ((Circle)figure).R;
                        SelectionRemove(ref storage);
                    for (int i = 0; i < storage.get_count(); ++i)
                        if (!storage.Empty(i))
                        {
                            if (Math.Sqrt(Math.Pow((x - storage.objects[i].x), 2) + Math.Pow((y - storage.objects[i].y), 2)) <= ((Circle)storage.objects[i]).R)
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
          
            storage.set_value(ref figure);

            //Снимаем выделение всех объектов хранилища
            SelectionRemove(ref storage);

            //Устанавливаем цвет выделяемого объекта на новый добавленный
            storage.objects[storage.get_count()-1].color = Color.Red;

            //Отрисовываем окружность
            DrawingCircles(ref storage, (storage.get_count()-1));

        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            panel1.Refresh(); //перерисовка
            for (int i = 0; i < storage.get_count() - 1; ++i)
                if (!storage.Empty(i))
                {
                    storage.objects[i].Is_Drawn = false; //значение отрисовки объекта= false
                    storage.objects[i].color = Color.Black;//убираем выделение объекта
                }

        }
        
        //Обработчик события Click кнопки "Показать объекты хранилища" 
        private void ShowCircle_button_Click(object sender, EventArgs e)
        {
            //Сначала очищается панель
           panel1.Refresh();

            //Если хранилище не пустое, то..
            if (storage.get_count() != 0)
                for (int i = 0; i < storage.get_count(); ++i)
                {
                    DrawingCircles(ref storage, i); //рисуется окружность,
                    if (!storage.Empty(i))
                        storage.objects[i].Is_Drawn = true; //устанавливается флаг(объект отрисован)
                }

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
