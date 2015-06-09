using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionBoxController : MonoBehaviour
{
    public Camera activeCamera;
    public LayerMask selectionMask;

    public bool isLooping = true;

    public 

    GameObject selectionBox;
    Transform selectionBoxTransform;
    Collider selectionBoxCollider;

    SelectionBox selectionScript;

    

    void Awake ()
    {
        selectionBox = new GameObject("Selection Box");
        selectionBoxTransform = selectionBox.transform;
        selectionBoxCollider = selectionBox.AddComponent<BoxCollider>();
        selectionBoxCollider.isTrigger = true;

        selectionScript = selectionBox.AddComponent<SelectionBox>();

        selectionBox.AddComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(Looper());
    }

    IEnumerator Looper ()
    {
        while (isLooping) {
            if (Input.GetButtonDown("Fire1")){
                selectionScript.ActivateSelectionProcess(true);
            }
            if (Input.GetButton("Fire1")){
                Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100f, selectionMask)) {
                    selectionBoxTransform.position = hit.point+Vector3.up;
                    
                }
            }
            yield return null;
        }
    }
}
