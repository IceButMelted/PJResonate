using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalContorller : MonoBehaviour
{
    public bool Open = false;
    private Animator animator;
    [SerializeField] private bool[] switchBool = new bool[3] ;
    public List<SwapSwitch> switchPatterns; 

    private bool canGo;
    private bool nextLv;
    public GameObject BtnE;
    public string nextScene;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        canGo = false;
    }

    private void Update()
    {
        if (switchPatterns[0].Pattern == switchBool[0] && switchPatterns[1].Pattern == switchBool[1] && switchPatterns[2].Pattern == switchBool[2]){
            Open = true;
            animator.SetBool("OpenPortal", Open);
            canGo = true;

        }
        else {
            Open = false;
            animator.SetBool("OpenPortal",Open);
            canGo = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && nextLv)
        {
            SceneManager.LoadScene(nextScene);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canGo && collision.tag == "Player")
        {
            BtnE.SetActive(true);
            nextLv = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BtnE.SetActive(false);
        }
        Debug.Log("uuu");
        nextLv = false;
    }


}
