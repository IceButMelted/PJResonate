using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public PlayerMovement PM;
    public bool IsTriggered = false;
    

    public void TriggerDialogue ()
    {
        
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //Debug.Log("open");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player") && IsTriggered == false) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
            PM.enabled = false;
            TriggerDialogue();
            IsTriggered = true;
            
        }
    }





   
}
