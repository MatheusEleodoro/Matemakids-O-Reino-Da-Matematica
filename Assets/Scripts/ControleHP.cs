using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleHP : MonoBehaviour {

    public static int Vidas = 3;
    public static bool bateu, Bateu;
    public float temp, fimtemp;

    void Start () {
        PlayerControlador.RecepVidas = Vidas;
	}
	
	
	void Update () {

   
        if (Vidas > 0 && bateu)
        {
            GameObject GVidas;
            
            switch (Vidas)
            {
                case 3:
                    GVidas = GameObject.Find("Coracao (3)") as GameObject;
                    GVidas.SetActive(false);
                    bateu = false;
                    PlayerControlador.sounddano = true;
                    Vidas--;
                    PlayerControlador.RecepVidas = Vidas;
                    
                    break;
                case 2:
                    GVidas = GameObject.Find("Coracao (2)") as GameObject;
                    GVidas.SetActive(false);
                    bateu = false;
                    PlayerControlador.sounddano = true;
                    Vidas--;
                    PlayerControlador.RecepVidas = Vidas;
                    
                    break;
                case 1:
                    GVidas = GameObject.Find("Coracao (1)") as GameObject;
                    GVidas.SetActive(false);
                    bateu = false;
                    PlayerControlador.sounddano = true;
                    Vidas--;
                    PlayerControlador.RecepVidas = Vidas;
                    
                    break;
            }
         
        }
    }
}
