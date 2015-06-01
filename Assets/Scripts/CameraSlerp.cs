using UnityEngine;
using System.Collections;

public class CameraSlerp : MonoBehaviour {

    public Transform rotationTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 relativePos = (rotationTarget.position + Vector3.up * 2f) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.rotation;


        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        transform.Translate(Vector3.forward * 4f * Time.deltaTime);
        
	}
}
