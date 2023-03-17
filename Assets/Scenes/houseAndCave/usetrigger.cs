using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usetrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private DialogueTrigger DT;
    public void GoGo() {
        DT.TriggerDialogue();
    }
}
