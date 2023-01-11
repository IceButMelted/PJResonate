using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class controlintensity : MonoBehaviour
{

    public Material mat;
    public float intensity = 12;
    public float maxRange = 254f;
    public float colorControl = 1f;
    public float t = 0.5f;
    public bool ForBacWarf = true;



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
            ForBacWarf = false;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ForBacWarf = true;

        }
        if (ForBacWarf == false) 
        {
            
        }

        if (ForBacWarf == true)
        {
            //mat.SetColor("_GlowColor", Color.Lerp(new Color(maxRange, maxRange, maxRange, 0), blackLerp, t));
            
        }
    }

    public void BToW() 
    {
        
    }
}
