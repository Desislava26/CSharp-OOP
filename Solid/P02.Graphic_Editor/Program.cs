﻿using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape shape = new Circle();
            GraphicEditor editor = new GraphicEditor();
            editor.DrawShape(shape);
        }
    }
}
