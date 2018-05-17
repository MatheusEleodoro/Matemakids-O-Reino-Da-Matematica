using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dificuldade : MonoBehaviour {
    private bool facil = false, medio = false, dificil = false, profissional = false, especialista = false, ativa1 = true,
    ativa2 = true, ativa3 = true, ativa4 = true, ativa5 = true;
    public static bool ativa6=false;
    private int cont = 0;
 
	
	void Start () {

	}

	void Update () {

        if (PlayerControlador.score >=10 && ativa1)
        {
            facil = true;
            ControleVelocidade();
            ativa1 = false;
        }
        if(PlayerControlador.score >20 && ativa2)
        {
            medio = true;
            ControleVelocidade();
            ativa2 = false;
        }
        if(PlayerControlador.score > 50 && ativa3)
        {
            dificil = true;
            ControleVelocidade();
            ativa3 = false;
        }
        if(PlayerControlador.score > 100 && ativa4)
        {
            profissional = true;
            ControleVelocidade();
            ativa4 = false;
        } 
        if(PlayerControlador.score > 250 && ativa5)
        {
            especialista = true;
            ControleVelocidade();
            ativa5 = false;
        }
        if (especialista)
        {
            ComplexidadeUP();
        }
	}

    void ControleVelocidade()
    {
        if(facil)
        {
            Debug.Log("Dificuldade FACIL UP");
            MoveTexture.velocidadeCeuUP = 0;
            MoveTexture.velocidadeSoloUP = 0;
            SpawControler.intervaloSpawUP = 0;
            MoverObjeto.velocidadeUP = 0;
            facil = false;
        }
        if (medio)
        {
            Debug.Log("Dificuldade MEDIO UP");
            MoveTexture.velocidadeCeuUP = -0.02f;
            MoveTexture.velocidadeSoloUP = 0.2f;
            SpawControler.intervaloSpawUP = -0.2f;
            MoverObjeto.velocidadeUP = -0.7f;
            medio = false;
        }
        if (dificil)
        {
           
            Debug.Log("Dificuldade DIFICIL UP");
            MoveTexture.velocidadeCeuUP = -0.05f;
            MoveTexture.velocidadeSoloUP = 0.7f;
            SpawControler.intervaloSpawUP = -0.6f;
            MoverObjeto.velocidadeUP = -1.2f;
            dificil = false;
        }
        if (profissional)
        {
           
            Debug.Log("Dificuldade PROFISSIONAL UP");
            MoveTexture.velocidadeCeuUP = 0.11f;
            MoveTexture.velocidadeSoloUP = 1.1f;
            SpawControler.intervaloSpawUP = -1f;
            MoverObjeto.velocidadeUP = -1.7f;
        }
        if (especialista)
        {
            Debug.Log("Dificuldade ESPECIALISTA UP");
            MoveTexture.velocidadeCeuUP = 0.17f;
            MoveTexture.velocidadeSoloUP = 1.5f;
            SpawControler.intervaloSpawUP = -1.5f;
            MoverObjeto.velocidadeUP = -2.2f;
        }
    }

   void ComplexidadeUP()
    {
        if (ativa6 && DesafioControl.complexidade <=10)
        {
             DesafioControl.complexidade++;
             MoverObjeto.contador = 0;
            Debug.Log("Complexidade APLICADA");
        }
        ativa6 = false;
    }
}
