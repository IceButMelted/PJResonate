using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour {

    
    public TextMeshProUGUI dialogueText;
    public GameObject UiWhileGame;
    public bool ShowUi;
    public GameObject Echo;
    public Animator EchoAnim;
    public GameObject DialogueOBJ;


    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start() {
        
        sentences = new Queue<string>();
        
    }

    public void StartDialogue (Dialogue dialogue)
    {
        DialogueOBJ.SetActive(true);
        UiWhileGame.SetActive(false);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }
        UiWhileGame.SetActive(false);
        string sentence= sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    { 
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

     public void EndDialogue() 
    {
        DialogueOBJ.SetActive(false);
        if(ShowUi) UiWhileGame.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindObjectOfType<PlayerMovement>().enabled = true;
        
        
        if (Echo != null && EchoAnim != null) {
            EchoAnim.SetInteger("state", 1);
            int distance = 0;
            while (distance < 50) {
                Echo.transform.position = new Vector3(Echo.transform.position.x + distance, Echo.transform.position.y, Echo.transform.position.z);
            }
            Echo.SetActive(false);
        }
    }
}
