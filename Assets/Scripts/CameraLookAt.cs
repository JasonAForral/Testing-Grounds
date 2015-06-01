using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour {


    public Transform cameraTarget;
    public bool yLock;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Vector3 relativePos = cameraTarget.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(relativePos);
        if (yLock) {
            Vector3 targetPosition = cameraTarget.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition, Vector3.up);
        } else {

            transform.LookAt(cameraTarget, Vector3.up);
        }
	}
}
