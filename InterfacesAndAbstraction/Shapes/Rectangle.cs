﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle: IDrawable
    {

        //public int Width { get; private set; }
        //public int Height { get; private set; }
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            DrawLine(this.width, '*', '*');
            for (int i = 0; i < this.height; i++)
            {
                DrawLine(this.width, '*', ' ');

            }
            DrawLine(this.width, '*', '*');
           
        }

        private void DrawLine(int width, char end, char mid )
        {
            Console.Write(end);
            for (int i = 0; i < width; i++)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
