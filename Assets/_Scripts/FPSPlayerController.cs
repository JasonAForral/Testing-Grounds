using UnityEngine;
using System.Collections;

public class FPSPlayerController : MonoBehaviour {

    public float movementFactor = 5f;
    public float rotationFactor = 90f;
    private Transform cameraTransform;

    private float verticalRotation = 0f;
    
	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
    void Update ()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        transform.Translate(movement * movementFactor * Time.deltaTime);

        float mouseHorizontal = Input.GetAxis("Mouse X");
        float mouseVertical = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseHorizontal * rotationFactor * Time.deltaTime);

        verticalRotation += mouseVertical * rotationFactor * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f);

        cameraTransform.localEulerAngles = Vector3.left * verticalRotation;
    }
}
