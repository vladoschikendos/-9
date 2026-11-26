using System;

abstract class Figure
{
    public string Color;
    public bool IsVisible = true;
    public double X, Y;

    public Figure(string color, double x, double y) { Color = color; X = x; Y = y; }

    public void MoveX(double d) { X += d; }
    public void MoveY(double d) { Y += d; }
    public void ChangeColor(string c) { Color = c; }

    public virtual void Show()
    {
        Console.WriteLine($"Фигура: {Color}, Видима: {IsVisible}, X: {X}, Y: {Y}");
    }
}

class Point : Figure
{
    public Point(string color, double x, double y) : base(color, x, y) { }

    public override void Show()
    {
        Console.WriteLine($"Точка: {Color}, Видима: {IsVisible}, X: {X}, Y: {Y}");
    }
}

class Circle : Point
{
    public double Radius;

    public Circle(string color, double x, double y, double r) : base(color, x, y) { Radius = r; }

    public double GetArea() { return Math.PI * Radius * Radius; }

    public override void Show()
    {
        Console.WriteLine($"Круг: {Color}, Видима: {IsVisible}, X: {X}, Y: {Y}, Радиус: {Radius}, Площадь: {GetArea():F2}");
    }
}

class Rectangle : Point
{
    public double W, H;

    public Rectangle(string color, double x, double y, double w, double h) : base(color, x, y) { W = w; H = h; }

    public double GetArea() { return W * H; }

    public override void Show()
    {
        Console.WriteLine($"Прямоугольник: {Color}, Видима: {IsVisible}, X: {X}, Y: {Y}, Ширина: {W}, Высота: {H}, Площадь: {GetArea()}");
    }
}

class Program
{
    static void Main()
    {
        Point p = new Point("Красная", 1, 2);
        Circle c = new Circle("Синий", 10, 10, 5);
        Rectangle r = new Rectangle("Зеленый", 0, 0, 4, 6);

        Console.WriteLine("--- ДО ---");
        p.Show();
        c.Show();
        r.Show();

        c.MoveX(5);
        c.ChangeColor("Желтый");
        r.MoveY(10);

        Console.WriteLine("\n--- ПОСЛЕ ---");
        p.Show();
        c.Show();
        r.Show();
    }
}