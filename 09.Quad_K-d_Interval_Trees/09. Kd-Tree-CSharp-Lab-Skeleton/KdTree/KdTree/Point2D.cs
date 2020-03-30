using System;

public class Point2D : IComparable<Point2D>
{

    public Point2D(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public double X { get; set; }
    public double Y { get; set; }


    public override string ToString()
    {
        return string.Format("({0}, {1})", this.X, this.Y);
    }

    public override bool Equals(object obj)
    {
        if (obj == this) return true;
        if (obj == null) return false;
        if (obj.GetType() != this.GetType()) return false; 
        Point2D other = (Point2D)obj;
        return this.X == other.X && this.Y == other.Y;
    }

    public override int GetHashCode()
    {
        int hashX = this.X.GetHashCode();
        int hashY = this.Y.GetHashCode();
        return 31 * hashX + hashY;
    }

    public int CompareTo(Point2D other)
    {
        //Compare by Y
        if (this.Y > other.Y) return +1;
        if (this.Y < other.Y) return -1;

        //Compare by X
        if (this.X < other.X) return -1;
        if (this.X > other.X) return +1;

        return 0;
    }
}
