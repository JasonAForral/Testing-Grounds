using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FPSPlayerController : MonoBehaviour {

    public Transform cameraPan;
    public Transform cameraTilt;
    public Transform cameraZoom;
    public float movementFactor = 5f;
    public float rotationFactor = 90f;
    
    public Vector3 jumpforce;

    public bool isGrounded;
    public LayerMask ground;

    public float throwForce;

    public LayerMask pickUpMask;
    private float verticalRotation = 0f;

    private Vector3 smoothVelocity;
    private Vector3 moveAmount;

    private Rigidbody rb;
    //private Transform cameraTransform;

    private bool isHolding;
    private Rigidbody held;
    
	// Use this for initialization
	void Start () {
        //cameraTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    void Update ()
    {
        Vector3 moveAxis = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));// * movementFactor * Time.deltaTime;

        moveAmount = Vector3.SmoothDamp(moveAmount, moveAxis, ref smoothVelocity, 0.15f);
        //transform.Translate(moveAxis);



        float mouseHorizontal = Input.GetAxis("Mouse X");
        float mouseVertical = Input.GetAxis("Mouse Y");

        cameraPan.Rotate(Vector3.up * mouseHorizontal * rotationFactor * Time.deltaTime);

        verticalRotation += mouseVertical * rotationFactor * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f);

        cameraTilt.localEulerAngles = Vector3.left * verticalRotation;

        if (isGrounded && Input.GetButtonDown("Jump")){
            rb.AddForce(jumpforce, ForceMode.Impulse);
        }

        if (isHolding) {
            Holding();
            FireHeld();
        } else {
            PickUpScan();
        }
    }

    void PickUpScan ()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraZoom.position, cameraZoom.forward, out hit, 2f, pickUpMask)) {
            //Debug.Log(hit.transform.name);
            if (Input.GetButtonDown("Use")){
                PickUp(hit.rigidbody);
            }
            
        } else {
        }
    }

    void PickUp (Rigidbody target)
    {
        held = target;
        held.transform.parent = transform;
        //held.angularVelocity = Vector3.zero;
        held.velocity = Vector3.zero;
        held.useGravity = false;
        
        isHolding = true;
    }

    void Holding ()
    {

        if (Input.GetButtonDown("Use")) {
            held.transform.parent = null;
            held.useGravity = true;
            
            isHolding = false;
        }
    }

    void FireHeld ()
    {

        if (Input.GetButtonDown("Fire1")) {
            held.transform.parent = null;
            held.useGravity = true;
            held.AddForce(cameraZoom.forward * throwForce, ForceMode.Impulse);
            isHolding = false;
        }
    }
    
    void FixedUpdate ()
    {
        rb.MovePosition(rb.position + cameraPan.TransformDirection(moveAmount) * movementFactor * Time.fixedDeltaTime);
        if (isHolding) {
            //held.velocity = Vector3.zero;
            held.MovePosition(cameraZoom.position + cameraZoom.forward * 1.5f);
            //held.MoveRotation(cameraPan.rotation);
            //held.position = (cameraDolly.position + cameraDolly.forward * 1.5f);
            //held.rotation = (transform.rotation);
        }
    }

    void OnTriggerStay ()
    {
        if (Physics.Raycast(transform.position+Vector3.up*0.1f, Vector3.down, .2f, ground)) {
        //if (Physics.CheckSphere(transform.position,0.25f, ground)){
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }
}
