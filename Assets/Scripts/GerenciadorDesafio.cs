using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDesafio : MonoBehaviour {

    private int vidas, quandochamar;
    private float temp, fimtemp;
    private bool Duas =true, UmaEmeia, Lose;
    public GameObject Cvidas1, Cvidas2, Cvidas3, Doublepoint;
    public static int score, acertos, AcertosTotal;
    public static bool recom =false, sorteio = true;
  


	void Start () {

	}

	void Update () {
     //   Debug.Log(acertos);
      //  Debug.Log(recom);
        if (score == 10)
        {
            DesafioControl.Active = true;
            score += 20;
        }
        if (recom)
        {
           // Debug.Log("Ativou");
            Recompensas();
        }
        if (score-20 >10)
        {
            if (sorteio)
            {
                quandochamar = ValidadorChamada();
                Debug.Log("Vou ativar de novo em :" + quandochamar);
                sorteio = false;
            }

            if(score -20 >= quandochamar)
            {
                DesafioControl.Active = true;
                sorteio = true;
            }
        }

    }
    void Recompensas()
    {

        vidas = ControleHP.Vidas;

        if (acertos == 4)
            {

                Debug.Log("Multiplicador 2x");
                Doublepoint.SetActive(true);
              
            if (vidas <= 3 && vidas > -1)
            {
                if (vidas == 0)
                {
                    Cvidas1.SetActive(true);
                    ControleHP.Vidas++;
                    Debug.Log("Vida1");
                    PlayerControlador.soundlife = true;
                    PlayerControlador.RecepVidas++;
                    AcertosTotal = acertos;
                    acertos = 0;
                    recom = false;
                }
                else if (vidas == 1)
                {
                    Cvidas2.SetActive(true);
                    ControleHP.Vidas++;
                    Debug.Log("Vida2");
                    PlayerControlador.soundlife = true;
                    PlayerControlador.RecepVidas++;
                    AcertosTotal = acertos;
                    acertos = 0;
                    recom = false;
                }
                else if (vidas == 2)
                {
                    Cvidas3.SetActive(true);
                    ControleHP.Vidas++;
                    Debug.Log("Vida3");
                    PlayerControlador.soundlife = true;
                    PlayerControlador.RecepVidas++;
                    AcertosTotal = acertos;
                    acertos = 0;
                    recom = false;
                }
                else if (vidas == 3)
                {
                    AcertosTotal = acertos;
                    acertos = 0;
                    recom = false;
                }


            }
        }

        if (acertos == 3)
        {
            AcertosTotal = acertos;
            acertos = 0;
            recom = false;
        }
 
        else if (acertos ==2 || acertos ==1)
        {
            ControleHP.bateu = true;
            Debug.Log(acertos);
            AcertosTotal = acertos;
            acertos = 0;
            recom = false;
        }

    }
   public int ValidadorChamada()

    {
        int resultado;
        resultado = Random.Range(PlayerControlador.score+5,PlayerControlador.score+20);
        return resultado;
    }
}
