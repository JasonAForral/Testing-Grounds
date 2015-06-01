using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour
{
    //public bool mouseLock;

    void Update ()
    {
        if (Input.GetButtonDown("Menu")) {
            if (Cursor.visible) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            } else {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}