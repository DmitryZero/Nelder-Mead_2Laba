namespace Nelder_Mead_2Laba
{
    class Point
    {
        public double X;
        public double Y;

        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);
        public static Point operator *(double k, Point p) => new Point(p.X * k, p.Y * k);
        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);
        public static Point operator /(Point p, double div) => new Point(p.X / div, p.Y / div);
        public override string ToString()
        {
            return "X:" + X + ", Y:" + Y;
        }
    }
}
