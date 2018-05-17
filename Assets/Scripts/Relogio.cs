using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Relogio : MonoBehaviour {

    public static float temp, fimtemp;
    public static bool liga ;
    public static int ID=0;
    public Text Numeros;
    public GameObject dobropoints,DoublePointButton, relogio, contador;
    private int num;
    private float screenWidth, screenHeight;
    void Start () {

        screenWidth = Screen.width;
        screenHeight = Screen.height;

        if (screenWidth == 1440 && screenHeight == 2960)
        {
            relogio.transform.position = new Vector3(1.029f, 3, transform.position.z);
        }
        

    }

    void Update () {

        if (!liga)
        {
            contador.SetActive(false);
            relogio.SetActive(false);
        }
        if (liga&&temp < fimtemp)
        {
            temp += Time.deltaTime;
            
            if (ID == 1)
            {
                DesafioControl.Active = false;
                GerenciadorDesafio.sorteio = false;
                int num;
                relogio.SetActive(true);
                contador.SetActive(true);
                num = Convert.ToInt32(temp);
                Numeros.text = num.ToString();
                float sx, sy;
                sx = dobropoints.transform.localScale.x;
                sy = dobropoints.transform.localScale.y;

                dobropoints.SetActive(true);
                sx += 0.5f * Time.deltaTime;
                sy += 0.5f * Time.deltaTime;
                dobropoints.transform.localScale = new Vector3(sx,sy,0);
                if(sx >= 1.5f)
                {
                    dobropoints.transform.localScale = new Vector3(1, 1, 0);
                }
   

                if (temp >= fimtemp)
                {
                    
                    MoverObjeto.multiplicador = 0;
                    Debug.Log("Multiplicador 0x");
                    GerenciadorDesafio.sorteio = true;
                    DesafioControl.Active = true;
                    dobropoints.SetActive(false);
                    contador.SetActive(false);
                    relogio.SetActive(false);
                    ID = 0;
                    liga = false;
                    temp = 0;
                }
            }
        }
	}

    public void DoublePoint()
    {
        MoverObjeto.multiplicador = 1;
        ID = 1;
        fimtemp = 30;
        liga = true;
        DoublePointButton.SetActive(false);
    }
}
