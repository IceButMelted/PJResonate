using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalContorller : MonoBehaviour
{
    public bool Open = false;
    private Animator animator;
    [SerializeField] private bool[] switchBool = new bool[3] ;
    public List<SwapSwitch> switchPatterns; 
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (switchPatterns[0].Pattern == switchBool[0] && switchPatterns[1].Pattern == switchBool[1] && switchPatterns[2].Pattern == switchBool[2]){
            Open = true;
            animator.SetBool("OpenPortal", Open);

        }
        else {
            Open = false;
            animator.SetBool("OpenPortal",Open);
        }
    }
}
