using UnityEngine;
using System.Collections;

public class VectorPractice : MonoBehaviour
{
    Camera mCam;
    Vector3 hitNormal = Vector3.right;

    void Awake()
    {
        mCam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 mouseWorldPos = mCam.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * -transform.localPosition.z);

        if (Input.GetButton("Fire1")) {
            hitNormal = mCam.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * -transform.localPosition.z).normalized;
        }
        
        Debug.DrawRay(Vector3.zero, hitNormal);
        Vector3 hitTangent = Vector3.Cross(hitNormal, Vector3.forward);
        Debug.DrawRay(Vector3.zero, hitTangent);
        Debug.DrawRay(Vector3.zero, mouseWorldPos, Color.green);
        Debug.DrawRay(Vector3.zero, hitNormal * Vector3.Dot(mouseWorldPos, hitNormal), Color.blue);

        Debug.DrawRay(Vector3.zero, hitTangent * Vector3.Dot(mouseWorldPos, hitTangent), Color.cyan);
        
    }
}
