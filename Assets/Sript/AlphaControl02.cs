using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AlphaControl02 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] MicrophoneInput microphoneInput;
    
    public TilemapRenderer tileMat;
    public PlayerMovement PM;
    
    public bool canUseAll = true;


    //map value
    public int inputMin = 10;
    public int inputMax = 40;
    public float outputMin = 1.0f;
    public float outputMax = 0.1f;
    public int valueToMap;

    //delay value
    public bool ISDELAYING = false;
    public float delayTimer = 0f;
    public float DELAY_TIME = 5f;


    public float fadeSpeedOut = 0.1f;
    public float fadeSpeedIn = 0.1f;
    private bool fadingIn = false;
    private bool fadingOut = false;

    private void Start()
    {
        //tileMat = GetComponent<TilemapRenderer>();
        tileMat.material.color = new Color(1f, 1f, 1f, 0f);

        //microphoneInput = GetComponent<MicrophoneInput>();
         
    }

    private void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log("this is from ahlphaControl02 : " + string.Join(", ", getting));
            SortArray();
            Debug.Log("this is from ahlphaControl02 sort : " + string.Join(", ", getting));
            
        }*/

        if (canUseAll == true)
        {

            if (ISDELAYING)
            {
                delayTimer += Time.deltaTime;
                if (delayTimer >= DELAY_TIME)
                {
                    ISDELAYING = false;
                    delayTimer = 0f;
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && !ISDELAYING && PM.IsGound())
            {
                PM.enabled = false;
            }
            /*if (microphoneInput.GetMicLevel() >= 0f) 
            { 

            }
            Debug.Log("what dB get : " + microphoneInput.GetMicLevel());*/

            if (Input.GetKeyUp(KeyCode.R) && !ISDELAYING && PM.IsGound())
            {
                ISDELAYING = true;
                fadingIn = true;
                fadingOut = false;
                PM.enabled = true;
                valueToMap = (int)microphoneInput.GetMicLevel();
                float mappedValue = MapValue(valueToMap, inputMin, inputMax, outputMin, outputMax);
                Debug.Log("Output db " + valueToMap);
                Debug.Log("Output value to map " + mappedValue);
                fadeSpeedOut = mappedValue;
            }

            /*if (microphoneInput.readings[0] != 0 ) 
            {
                StartFadeOut(fadeSpeedOut);
            }*/
            StartFadeOut(fadeSpeedOut);

        }
        

    }




    //function part
    private void StartFadeOut(float fadeSpeedOut)
    {
        if (fadingIn)
        {
            FadeIn();
        }

        if (fadingOut)
        {
            FadeOut(fadeSpeedOut);
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

    private void FadeOut(float timefading)
    {
        float alpha = tileMat.material.color.a;
        alpha -= timefading * Time.deltaTime;

        if (alpha < 0)
        {
            alpha = 0;
            fadingOut = false;
        }

        tileMat.material.color = new Color(1f, 1f, 1f, alpha);
    }

    float MapValue(int value, int fromLow, int fromHigh, float toLow, float toHigh)
    {
        // Map the input value from the input range to the output range
        float fromRange = fromHigh - fromLow;
        float toRange = toHigh - toLow;
        float scaledValue = (float)(value - fromLow) / fromRange;
        float mappedValue = toLow + (scaledValue * toRange);
        return mappedValue;
    }

}
