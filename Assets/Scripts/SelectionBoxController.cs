using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionBoxController : MonoBehaviour
{
    public Camera activeCamera;
    public LayerMask selectionMask;

    public bool isLooping = true;

    //public GameObject selectionBox;
    //Collider selectionBoxCollider;
    //Material selectionMaterial;
    public SelectionBox selectionScript;
    Transform selectionBoxTransform;

    Vector3 pointA;
    Vector3 pointB;

    public LayerMask groundMask;

    bool isDragging;



    void Awake()
    {
        //selectionBox = new GameObject("Selection Box");
        selectionBoxTransform = selectionScript.transform;
        //selectionBoxCollider = selectionBox.GetComponent<BoxCollider>();
        //selectionBoxCollider.isTrigger = true;

        //selectionScript = selectionScript.GetComponent<SelectionBox>();

        //selectionBox.AddComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(Looper());
    }

    IEnumerator Looper()
    {
        while (isLooping) {
            if (Input.GetButtonDown("Fire1")) {
                isDragging = true;
                selectionScript.ActivateSelectionProcess(true);
                selectionBoxTransform.gameObject.SetActive(true);

                Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100f, selectionMask)) {
                    pointA = hit.point;
                    selectionScript.selectedItems.Clear();

                }
            }
            if (Input.GetButton("Fire1")) {
                if (isDragging) {
                    Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 100f, selectionMask)) {
                        pointB = hit.point;
                        selectionBoxTransform.position = Vector3.Lerp(pointA, pointB, 0.5f) + Vector3.up * 0.75f;
                        selectionBoxTransform.localScale = Vector3.Max(pointA, pointB) - Vector3.Min(pointA, pointB) + Vector3.up * 1.5f;
                    }
                }
            }


            if (Input.GetButtonUp("Fire1")) {
                isDragging = false;
                selectionScript.ActivateSelectionProcess(false);
                selectionBoxTransform.gameObject.SetActive(false);

                selectionBoxTransform.position = selectionBoxTransform.localScale = Vector3.zero;
            }

            yield return null;
        }
    }
}
