using UnityEngine;
using System.Collections;

public class FollowingBody : MonoBehaviour
{
    public Transform mind;
    public float followSpeed;
    public bool yOnly;

    void LateUpdate ()
    {
        //transform.position = mind.position;
        if (transform.rotation != mind.rotation) {
            if (yOnly) {
                Vector3 mindRotation = mind.rotation.eulerAngles;
                mindRotation.x = 0f;
                mindRotation.z = 0f;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(mindRotation), followSpeed * Time.deltaTime);
            } else {
                transform.rotation = Quaternion.Lerp(transform.rotation, mind.rotation, followSpeed * Time.deltaTime);
            }
        }

    }
}