using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaClamp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Transform targetToFollow;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;  

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, minX, maxX),
            Mathf.Clamp(targetToFollow.position.y, minY, maxY),
            transform.position.z
            ); 

    }
}
