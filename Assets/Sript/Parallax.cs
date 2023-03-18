using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallexEffect;
    public bool followY;
    public bool followX;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followX)
        {
            float temp = (cam.transform.position.x * (1 - parallexEffect));
            float dist = (cam.transform.position.x * parallexEffect);

            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

            if (temp > startpos + length) startpos += length;
            else if (temp < startpos - length) startpos -= length;

        }
        if (followY) 
        {
            transform.position = new Vector3(transform.position.x, cam.transform.position.y, transform.position.z);
        }
    }
}
