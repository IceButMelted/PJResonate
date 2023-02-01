using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class controlintensity : MonoBehaviour
{

    public Material mat;
    public float minusRate = 1f;
    public float colorControl = 1f;

    public Color color1;
    public Color color2;

    public float t = 3f;
    public int ForBacWarf = 0;



    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<TilemapRenderer>().material;
        //Vector4 colorVec = new Vector4(10,11,12,0);
        //mat.SetVector("_GlowColor",colorVec);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ForBacWarf = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ForBacWarf = 0;
        }

        if (ForBacWarf == 0){
            StartCoroutine(FadeColorUp());
            ForBacWarf = 1;
        }
                
            
        
            //mat.SetColor("_GlowColor", Color.Lerp(new Color(maxRange, maxRange, maxRange, 0), blackLerp, t));
            
        
    }
    
    IEnumerator FadeColorUp()
    {
        //Renderer renderer = GetComponent<Renderer>();
        mat = GetComponent<TilemapRenderer>().material;
        Color startColor = new Color(0, 0, 0, 0); 
        Color endColor = new Color(255, 255, 255, 255);
        float duration = 3f;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            mat.SetColor("_ColorAlpha", currentColor);
            //Debug.Log("from function" + redColor + " " + greenColor + " " + blueColor);
            yield return null ;
        }
        duration = 3f;
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            Color currentColor1 = Color.Lerp(endColor, startColor, t);
            mat.SetColor("_ColorAlpha", currentColor1);
            //Debug.Log("from function" + redColor + " " + greenColor + " " + blueColor);
            yield return null;
        }
    }

}
