using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_bt : MonoBehaviour
{
    public void doExitGame() {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
