using UnityEngine;
using System.Collections;

public class TowerID : MonoBehaviour
{
    public static TowerID towerID;

    public int bigNumber = 512;
    public static int biggerNumber = 513;

    void Awake ()
    {
        if (null == towerID)
            towerID = this;
    }
}