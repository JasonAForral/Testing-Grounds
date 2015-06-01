using UnityEngine;
using System.Collections;



public class OperationTests : MonoBehaviour
{
    float x;
    void Awake ()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        Vector3 a = Vector3.up * 11.0f;
        Vector3 b = Vector3.one * 9.0f;
        for (int j = 0; j < 5; j++)
        {
            sw.Start();
            for (int i = 0; i < 4194304; i++)
            {
                x = sqrMag(new Vector3(a.x - b.x, a.y - b.y, a.z - b.z));
            }

            sw.Stop();
            print("Test " + j + " Complete: " + sw.ElapsedMilliseconds + " ms");
            sw.Reset();

        }
        Debug.Log(x);



    }

    float sqrMag (Vector3 a, Vector3 b)
    {
        Vector3 c = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        return sqrMag(c);
        //return ((a.x - b.x) * (a.x - b.x)) + ((a.y - b.y) * (a.y - b.y)) + ((a.z - b.z) * (a.z - b.z));
    }

    float sqrMag (Vector3 c)
    {
        return (c.x * c.x) + (c.y * c.y) + (c.z * c.z);
     
    }
}