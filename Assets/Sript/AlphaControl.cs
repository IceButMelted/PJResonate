using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class AlphaControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    private Material material;

    private void Start()
    {
        material = GetComponent<TilemapRenderer>().material;
    }

    private void Update()
    {
        material.GetFloat("_FloatAlpha");
        float a = Mathf.Sin(Time.time * speed) * 0.5f + 0.5f;
        material.SetFloat("_FloatAlpha", a);
    }

}
