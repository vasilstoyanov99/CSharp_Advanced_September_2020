using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            Circle circle = new Circle("I'm a circle");
            GraphicEditor editor = new GraphicEditor();
            editor.DrawShape(circle);
            Rectangle rectangle = new Rectangle("I'm a rectangle");
            editor.DrawShape(rectangle);
            Square square = new Square("I'm a square");
            editor.DrawShape(square);
        }
    }
}
