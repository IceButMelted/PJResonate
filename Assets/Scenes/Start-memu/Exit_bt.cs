using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_bt : MonoBehaviour
{
    private void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void doExitGame() {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
