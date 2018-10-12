using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS : MonoBehaviour {

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MousePointNone() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void MousePointLock() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
