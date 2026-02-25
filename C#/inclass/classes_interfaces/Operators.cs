using System;

public class Adder : I365, IComparable
{
    public float LeftValue { get; set; }
    public float RightValue { get; set; }

    public Adder(float left, float right)
    {
        LeftValue = left;
        RightValue = right;
    }

    public float Operator()
    {
        return LeftValue + RightValue;
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        if (obj is not I365 other)
            throw new ArgumentException("Object is not an I365");

        return Operator().CompareTo(other.Operator());
    }
}

public class Subber : I365, IComparable
{
    public float LeftValue { get; set; }
    public float RightValue { get; set; }

    public Subber(float left, float right)
    {
        LeftValue = left;
        RightValue = right;
    }

    public float Operator()
    {
        return LeftValue - RightValue;
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        if (obj is not I365 other)
            throw new ArgumentException("Object is not an I365");

        return Operator().CompareTo(other.Operator());
    }
}
