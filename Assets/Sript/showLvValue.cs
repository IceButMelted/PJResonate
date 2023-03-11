using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showLvValue : MonoBehaviour
{
    //get outer source
    public AlphaControl02 alphaControl;
    public PlayerMovement PM;
    public MicrophoneInput microphoneInput;
    public Text txtCoolDown;
    public GameObject soundBar;
    public GameObject UiMenu;
    public Text txtdB;
    public Image dBBar;
    public float CoolDown;

    private bool reading = false;
    private bool UiCanSee = false;


    //for mapping
    public int inputMin = 10;
    public int inputMax = 40;
    public float outputMin = 1.0f;
    public float outputMax = 0.1f;
    public float valueToMap;
    // Start is called before the first frame update
    void Start()
    {
        txtdB.enabled = false;
        soundBar.SetActive(false);  
        dBBar.transform.localScale = new Vector3(1f, 0f, 1f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        float timeer = alphaControl.DELAY_TIME - alphaControl.delayTimer;
        if (timeer == 5)
        {
            txtCoolDown.text = "Ready";
            if (reading) txtCoolDown.text = "Using";
        }
        else 
        {
            CoolDown = Mathf.Round(timeer * 100f) / 100f;
            txtCoolDown.text = "CoolDown\n"+ CoolDown+"";
        }


        if (Input.GetKeyDown(KeyCode.R) && !alphaControl.ISDELAYING) 
        {
            reading = true;
            txtdB.enabled = true;
            soundBar.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.R) && !alphaControl.ISDELAYING)
        {
            reading = false;
            txtdB.enabled = false;
            soundBar.SetActive(false);
        }

        if (reading)
        {
            valueToMap = Mathf.RoundToInt(microphoneInput.GetMicLevel());
            float mappedValue = MapValue(valueToMap, inputMin, inputMax, outputMin, outputMax);
            if(mappedValue <= 0) mappedValue = 0;
            swapColor();
            dBBar.transform.localScale = new Vector3(1f,mappedValue,1f);
            if (valueToMap <= 0) txtdB.text = "0";
            else txtdB.text = "" + valueToMap;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && UiCanSee == false) 
        {
            PM.enabled = false;
            UiMenu.SetActive(true);
            UiCanSee = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && UiCanSee == true)
        {
            PM.enabled = true;
            UiMenu.SetActive(false);
            UiCanSee = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }



    }

    void swapColor() 
    {
        if (valueToMap >= 0 && valueToMap < 10) dBBar.color = new Color(1f,1f,1f);
        if (valueToMap >= 10 && valueToMap < 20) dBBar.color = new Color(0f, 1f, 0f);
        if (valueToMap >= 20 && valueToMap < 30) dBBar.color = new Color(1f, 1f, 0f);
        if (valueToMap >= 30 && valueToMap <= 40) dBBar.color = new Color(1f, 0f, 0f);
    }


    float MapValue(float value, int fromLow, int fromHigh, float toLow, float toHigh)
    {
        // Map the input value from the input range to the output range
        float fromRange = fromHigh - fromLow;
        float toRange = toHigh - toLow;
        float scaledValue = (float)(value - fromLow) / fromRange;
        float mappedValue = toLow + (scaledValue * toRange);
        return mappedValue;
    }
}
