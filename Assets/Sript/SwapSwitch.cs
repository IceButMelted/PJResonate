using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSwitch : MonoBehaviour
{
    public Sprite[] spriteArray;
    public int indexSprite = 0;
    public bool Pattern = false;
    public bool CanPress = false;
    private SpriteRenderer spriteRenderer;
    public GameObject btnE;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SwapSprite();
    }

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


    public void SwapSprite() {
        if (Input.GetKeyDown(KeyCode.E) && CanPress == true)
        {
            if (indexSprite == 1)
            {
                indexSprite = 0;
            }
            else if (indexSprite == 0)
            {
                indexSprite = 1;
            }
        }

        spriteRenderer.sprite = spriteArray[indexSprite];
        if (spriteRenderer.sprite == spriteArray[0] ) {
            Pattern = false;

        }
        if (spriteRenderer.sprite == spriteArray[1]) {
            Pattern = true;

        }
        
    }
}
