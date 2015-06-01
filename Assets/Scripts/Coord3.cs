using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Coord3 
{
    public Vector3 _inverse;

    public Vector3 inverse
    {
        get
        {
            return _inverse;
        }
    }

    private Point3 _count;

    public Point3 count
    {
        get
        {
            return _count;
        }
        set
        {
            _inverse = Inverse(value);
            _count = value;
        }
    }

    public Coord3 (Point3 point)
    {
        _count = point;
        _inverse = Inverse(point);
        Debug.Log(inverse);

    }

    public static Vector3 Inverse (Point3 value)
    {
        Vector3 output= new Vector3();
        if (0 != value.x)
        {
            output.x = 1f / (float)value.x;
        }
        if (0 != value.y)
        {
            output.y = 1f / (float)value.y;
        }
        if (0 != value.z)
        {
            output.z = 1f / (float)value.z;
        }
        Debug.Log("this Happened:");
        return output;
    }

    public static Coord3 operator + (Coord3 a, int b)
    {
        return new Coord3(a.count + b);
    }
}
