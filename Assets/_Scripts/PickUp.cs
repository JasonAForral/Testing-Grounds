using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    void OnTriggerEnter (Collider other)
    {
        Debug.Log(other.tag);
        other.gameObject.SetActive(false);  
    }
}
