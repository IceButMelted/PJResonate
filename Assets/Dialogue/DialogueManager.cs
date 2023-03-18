using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour {


    public TextMeshProUGUI dialogueText;
    public GameObject UiWhileGame;
    public bool tut1;
    public GameObject tut1G;
    public bool tut2;
    public GameObject tut2G;
    public bool ShowUi;
    public bool EchoCheck;
    public Animator EchoAnim;
    public GameObject DialogueOBJ;


    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start() {

        sentences = new Queue<string>();


    }

    public void StartDialogue(Dialogue dialogue)
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
        string sentence = sentences.Dequeue();
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
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindObjectOfType<PlayerMovement>().enabled = true;
        if (EchoCheck) {
            EchoAnim.SetInteger("state", 10);
        }
        if (tut1) {
            if (ShowUi) UiWhileGame.SetActive(true);
            FindObjectOfType<PlayerMovement>().enabled = false;
            UiWhileGame.SetActive(false);
            tut1G.SetActive(true);
            tut1 = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void EndTut(){
        tut2G.SetActive(false);
        tut1G.SetActive(false);
        DialogueOBJ.SetActive(false);
        if (ShowUi) UiWhileGame.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindObjectOfType<PlayerMovement>().enabled = true;
    }
}
