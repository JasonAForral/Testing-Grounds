using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform cameraTilt;
    public Transform cameraDolly;

    public float rotateSpeed = 1f;
    public float mouseSlideSpeed = 1f;
    public float keyboardSlideSpeed = 1f;
    public float dollySpeed = 50f;
    public float panSpeed = 1f;
    public float lerpSpeed = 1f;

    private float verticalRotation;
    public Vector3 dollyPosition;

    // Use this for initialization
    void Awake ()
    {
        if (null == cameraTilt) {
            cameraTilt = transform.GetChild(0);
        }
        if (null == cameraDolly) {
            cameraDolly = cameraTilt.GetChild(0);
        }

        verticalRotation = cameraTilt.eulerAngles.x;
        dollyPosition = cameraDolly.localPosition;
    }

    void LateUpdate ()
    {
        if (Input.GetButton("Fire2")) {
            transform.Translate(-1.0f * panSpeed * mouseSlideSpeed * new Vector3(Input.GetAxis("Mouse X"), 0.0f, Input.GetAxis("Mouse Y")));
        }

        if (Input.GetButton("Fire3")) {
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * rotateSpeed);
            //cameraTilt.Rotate(Vector3.left * Input.GetAxisRaw("Mouse Y") * rotateSpeed);
            verticalRotation -= Input.GetAxisRaw("Mouse Y") * rotateSpeed;
            verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

            //float verticalRotation = cameraTilt.localEulerAngles.x;
            //verticalRotation -= (verticalRotation > 180 ? 360f : 0f);
            cameraTilt.localEulerAngles = Vector3.right * verticalRotation;


        }


        dollyPosition.z += Input.GetAxis("Mouse ScrollWheel") * dollySpeed;
        dollyPosition.z = Mathf.Round(Mathf.Clamp(dollyPosition.z, -110f, -5f));


        ClampDolly();

        panSpeed = -dollyPosition.z * 0.01f;
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * panSpeed * keyboardSlideSpeed);

    }

    void ClampDolly ()
    {
        Ray ray = new Ray(cameraTilt.position, -cameraTilt.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, -dollyPosition.z)) {
            Vector3 cap = new Vector3(dollyPosition.x, dollyPosition.y, 0.15f - hit.distance);
            //dollyGlobalDestination = transform.position + transform.TransformDirection(cameraTilt.position) + cameraTilt.TransformDirection(cap);

            if (cameraDolly.localPosition.z > cap.z) {
                cameraDolly.localPosition = Vector3.Lerp(cameraDolly.localPosition, cap, lerpSpeed * Time.deltaTime);
            } else {
                cameraDolly.localPosition = cap;
            }

        } else {
            //dollyGlobalDestination = cameraTilt.position + cameraDolly.TransformDirection(dollyPosition);
            if (cameraDolly.localPosition != dollyPosition) {
                cameraDolly.localPosition = Vector3.Lerp(cameraDolly.localPosition, dollyPosition, lerpSpeed * Time.deltaTime);
            }
        }
    }

    void OnDrawGizmos ()
    {
        if (null != cameraDolly && null != cameraTilt) {
            Gizmos.color = Color.green;
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, cameraTilt.position);
            Gizmos.DrawRay(cameraDolly.position, cameraDolly.forward);
            
        }
    }
}