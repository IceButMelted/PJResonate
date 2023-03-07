using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AlphaControl02 : MonoBehaviour
{
    // Start is called before the first frame update


    public float fadeSpeedOut = 0.1f;
    public float fadeSpeedIn = 0.1f;
    private TilemapRenderer tileMat;
    private bool fadingIn = false;
    private bool fadingOut = false;

    private void Start()
    {
        tileMat = GetComponent<TilemapRenderer>();
        tileMat.material.color = new Color(1f, 1f, 1f, 0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            fadingIn = true;
            fadingOut = false;
            FadeIn();
        }

        if (fadingIn)
        {
            FadeIn();
        }

        if (fadingOut)
        {
            FadeOut();
        }
    }

    private void FadeIn()
    {
        float alpha = tileMat.material.color.a;
        alpha += fadeSpeedIn * Time.deltaTime;

        if (alpha > 1)
        {
            alpha = 1;
            fadingIn = false;
            fadingOut = true;
            Invoke("StartFadeOut", 3f);
        }

        tileMat.material.color = new Color(1f, 1f, 1f, alpha);
    }

    private void FadeOut()
    {
        float alpha = tileMat.material.color.a;
        alpha -= fadeSpeedOut * Time.deltaTime;

        if (alpha < 0)
        {
            alpha = 0;
            fadingOut = false;
        }

        tileMat.material.color = new Color(1f, 1f, 1f, alpha);
    }

    private void StartFadeOut()
    {
        fadingIn = false;
        fadingOut = true;
    }
}
