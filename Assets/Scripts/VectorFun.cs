using UnityEngine;
using System.Collections;

public class VectorFun : MonoBehaviour
{
    void Update()
    {
        Ray ray = new Ray(transform.position + (Vector3.down + Vector3.right) * 0.5f, Vector3.right);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1f)) {
            Vector3 rightAngle = Vector3.Cross(hit.normal, Vector3.forward);
            Debug.DrawRay(Vector3.zero, rightAngle);
            transform.Translate(rightAngle * Time.deltaTime);
        }
    }
}
