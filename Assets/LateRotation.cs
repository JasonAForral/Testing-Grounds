using UnityEngine;
using System.Collections;

public class LateRotation : MonoBehaviour
{
    public Transform target;

    void LateUpdate ()
    {
        transform.rotation = target.rotation;
    }
}