using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Interac : MonoBehaviour
{
    public bool CanPress = false;
    [SerializeField]private GameObject btnE;
    public GameObject targetObject;
    public string targetFunctionName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            btnE.gameObject.SetActive(true);
            CanPress = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        btnE.gameObject.SetActive(false);
        CanPress = false;
    }

    private void Update()
    {
        if (CanPress && Input.GetKeyDown(KeyCode.E))
        {
            if (targetObject != null && !string.IsNullOrEmpty(targetFunctionName))
            {
                targetObject.SendMessage(targetFunctionName);
            }
        }
    }


}
