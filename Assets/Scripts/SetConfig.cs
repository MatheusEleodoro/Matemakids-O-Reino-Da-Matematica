using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetConfig : MonoBehaviour {
    public GameObject TamanhoUIback;
    private float screenWidth, screenHeight;
    void Start () {

        screenHeight = Screen.height;
        screenWidth = Screen.width;
        if (screenWidth ==1440 && screenHeight == 2960)
        {
            TamanhoUIback.GetComponent<TamanhoUI>().enabled = true;
        }
        
	}
	
}
