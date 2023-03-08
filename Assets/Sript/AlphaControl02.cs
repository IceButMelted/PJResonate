using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AlphaControl02 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] MicrophoneInput microphoneInput;
    public float fadeSpeedOut = 0.1f;
    public float fadeSpeedIn = 0.1f;
    public TilemapRenderer tileMat;
    public PlayerMovement PM;
    private bool fadingIn = false;
    private bool fadingOut = false;
    private float[] getting;

    //delay value
    private bool ISDELAYING = false;
    private float delayTimer = 0f;
    private const float DELAY_TIME = 5f;
    //private int mapping; 

    private void Start()
    {
        //tileMat = GetComponent<TilemapRenderer>();
        tileMat.material.color = new Color(1f, 1f, 1f, 0f);

        //microphoneInput = GetComponent<MicrophoneInput>();
        getting = new float[microphoneInput.numReadings]; 
    }

    private void Update()
    {
        getting = microphoneInput.readings;

        /*if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log("this is from ahlphaControl02 : " + string.Join(", ", getting));
            SortArray();
            Debug.Log("this is from ahlphaControl02 sort : " + string.Join(", ", getting));
            
        }*/

        if (ISDELAYING)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= DELAY_TIME)
            {
                ISDELAYING = false;
                delayTimer = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && !ISDELAYING)
        {
            PM.enabled = false;
        }

        microphoneInput.getArrayfromMic();

        if (Input.GetKeyUp(KeyCode.R) && !ISDELAYING)
        {
            ISDELAYING = true;
            fadingIn = true;
            fadingOut = false;
            PM.enabled = true;
        }


        //if (getting[0] != 0)
        //{
            StartFadeOut();
        //}


    }

    private void StartFadeOut()
    {
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
            //Invoke("StartFadeOut", 3f);
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
    private void SortArray()
    {
        int n = getting.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (getting[j] < getting[j + 1])
                {
                    float temp = getting[j];
                    getting[j] = getting[j + 1];
                    getting[j + 1] = temp;
                }
            }
        }
    }


}
