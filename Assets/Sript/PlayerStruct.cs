using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStruct : MonoBehaviour
{

    public class Characteer {
        public string name;
        public int exp = 0;
        public int health = 10;

        public Characteer() {
            name = "Not assigned!!";
        }

        public Characteer(string name) {
            this.name = name;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Characteer hero = new Characteer();
        Debug.Log("Hero: " + hero.name);

        Characteer fuckyou = new Characteer("kuy");
        Debug.Log("fuckyou: " + fuckyou.name);

        fuckyou.exp = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
