using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class AlphaControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    private Material material;
    public bool starter = false; 
    float timeSinceLastFire = 0f;

    private void Start()
    {
        material = GetComponent<TilemapRenderer>().material;
        material.GetFloat("_FloatAlpha");
        material.SetFloat("_FloatAlpha", 0);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            starter = true;
        }

        if (starter == true)
        {
            timeSinceLastFire += Time.deltaTime;
            if (timeSinceLastFire > 7.5f)
            {
                timeSinceLastFire = 0f;
                Debug.Log("Time is up");
                starter = false;
            }
            else if (timeSinceLastFire < 7.5f)
            {
                tilefading();
                Debug.Log("Time is not up");
            } 
        }
    }

    public void tilefading() 
    {
        material.GetFloat("_FloatAlpha");
        float a = Mathf.Sin(Time.time * speed) * 0.5f + 0.5f;
        //Debug.Log(Time.time);
        material.SetFloat("_FloatAlpha", a);
    
    }

}
