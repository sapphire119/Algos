using System;

public class Interval
{
    public double Low { get; set; }
    public double High { get; set; }

    public Interval(double low, double high)
    {
        ValidateInterval(low, high);
        this.Low = low;
        this.High = high;
    }

    public bool Intersects(double low, double high)
    {
        ValidateInterval(low, high);
        return this.Low < high && this.High > low;
    }

    public override bool Equals(object obj)
    {
        var other = (Interval)obj;
        return this.Low == other.Low && this.High == other.High;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1})", this.Low, this.High);
    }

    private static void ValidateInterval(double low, double high)
    {
        if (high < low)
        {
            throw new ArgumentException();
        }
    }
}
