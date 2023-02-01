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
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Color color = material.GetColor("_ColorAlpha");
        color.a = Mathf.Sin(Time.time * speed) * 0.5f + 0.5f;
        material.SetColor("_ColorAlpha", color);
    }

}
