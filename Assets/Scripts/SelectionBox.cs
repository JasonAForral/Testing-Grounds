using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionBox : MonoBehaviour
{
    public bool isSelecting;
    public List<GameObject> selectedItems = new List<GameObject>();

    public void ActivateSelectionProcess(){
        ActivateSelectionProcess(!isSelecting);
    }

    public void ActivateSelectionProcess (bool value)
    {
        isSelecting = value;
    }
    void OnTriggerEnter (Collider other)
    {

        if (isSelecting) {
            Debug.Log(other.name + " selected");
            selectedItems.Add(other.gameObject);
        }

    }

    void OnTriggerExit (Collider other)
    {
        if (isSelecting) {
            Debug.Log(other.name + " unselected");
            selectedItems.Remove(other.gameObject);
        }
    }
}
