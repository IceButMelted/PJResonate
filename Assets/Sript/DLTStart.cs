using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DLTStart : MonoBehaviour
{
    public Dialogue dialogue;
    public AlphaControl02 ALPHA;
    public PlayerMovement PM;
    public bool IsTriggered = false;

    public void TriggerDialogue()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PM.enabled = false;
        PM.SendMessage("defaultAnim");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //Debug.Log("open");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && IsTriggered == false)
        {
            /*Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
            PM.enabled = false;*/
            TriggerDialogue();
            IsTriggered = true;
            ALPHA.canUseAll = true;
        }
    }








}
