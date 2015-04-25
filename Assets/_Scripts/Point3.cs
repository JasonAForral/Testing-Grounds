using UnityEngine;
//using System;
using System.Collections;
//using Random = UnityEngine.Random; 

[System.Serializable]
public struct Point3 {

    public int x, y, z;

    public int this[int index]
    {
        get
        {
            if (0 == index)
                return x;
            if (1 == index)
                return y;
            if (2 == index)
                return y;
            return 0;
        }
                set
        {
            if (0 == index)
                x = value;
            else if (1 == index)
                y = value;
            else if (2 == index)
                z = value;
        }
    }


    public Point3 (int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static Point3 zero = new Point3(0, 0, 0);
    public static Point3 one = new Point3(1, 1, 0);

    public static Point3 down = new Point3(0, -1, 0);
    public static Point3 up = new Point3(0, 1, 0);
    
    public static Point3 left = new Point3(-1, 0, 0);
    public static Point3 right = new Point3(1, 0, 0);

    public static Point3 back = new Point3(0, 0, -1);
    public static Point3 forward = new Point3(0, 0, 1);

    public static int sqrMagnitude (Point3 a)
    {
        return (a.x * a.x) + (a.y * a.y) + (a.z * a.z);
    }

    public int SqrMagnitude
    {
        get
        {
            return sqrMagnitude(this);
        }
    }

    // Point3 + Point3

    public static Point3 operator + (Point3 a, Point3 b)
    {
        return new Point3(a.x + b.x, a.y + b.y, a.y + b.y);
    }

    // Point3 - Point3

    public static Point3 operator - (Point3 a, Point3 b)
    {
        return new Point3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    // Point3 * int

    public static Point3 operator * (Point3 a, int b)
    {
        return new Point3(a.x * b, a.y * b, a.z * b);
    }

    // int * Point3

    public static Point3 operator * (int b, Point3 a)
    {
        return new Point3(a.x * b, a.y * b, a.z * b);
    }

    // Point3 + int

    public static Point3 operator + (Point3 a, int b)
    {
        return new Point3(a.x + b, a.y + b, a.z + b);
    }

    // Point3 - int

    public static Point3 operator - (Point3 a, int b)
    {
        return new Point3(a.x - b, a.y - b, a.z - b);
    }

    public static bool operator == (Point3 a, Point3 b)
    {
        return (a.x == b.x) && (a.y == b.y) && (a.z == b.z);
    }

    public static bool operator != (Point3 a, Point3 b)
    {
        return (a.x != b.x) || (a.y != b.y) || (a.z != b.z);
    }

    public override bool Equals (System.Object obj)
    {
        return false;
    }

    public bool Equals (Point3 p)
    {
        // Return true if the fields match:
        return base.Equals((Point3)p) && z == p.z;
    }

    public override int GetHashCode ()
    {
        return base.GetHashCode() ^ z;
    }

    public override string ToString ()
    {
        return "(" + x + ", " + y + ", " + z + ")";
    }
}
