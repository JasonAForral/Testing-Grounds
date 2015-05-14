using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour {


    public Transform cameraTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 relativePos = cameraTarget.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
	}
}
