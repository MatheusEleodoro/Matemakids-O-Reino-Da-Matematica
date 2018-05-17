using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamanhoUI : MonoBehaviour {

    public float A, B, screenWidth, screenHeight;
    
    
   

    // Use this for initialization
    void Start()
    {
        A = transform.localScale.x+0.75f;
        B = transform.localScale.y;
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        transform.localScale = new Vector3((A * screenWidth / screenHeight), transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
