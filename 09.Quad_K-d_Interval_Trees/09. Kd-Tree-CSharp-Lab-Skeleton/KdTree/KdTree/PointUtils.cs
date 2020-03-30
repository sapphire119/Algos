public static class PointUtils
{
    public static int CompareByX(this Point2D point, Point2D other)
    {
        if (other.X < point.X) return -1;
        if (other.X > point.X) return +1;

        return 0;
    }

    public static int CompareByY(this Point2D point, Point2D other)
    {
        if (other.Y < point.Y) return -1;
        if (other.Y > point.Y) return +1;

        return 0;
    }
}