using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjeto : MonoBehaviour {
    public float velocidade;
    public static float velocidadeUP = 0; 
    private float px;
    public GameObject Player;
    private bool scored;
    public static bool DestroyInst = false;
    public static bool bateu;
    public static int multiplicador = 0;
    public static int contador = 0;
	void Start () {
        Player = GameObject.Find("Player") as GameObject;
        bateu = false;
       
	}
	
	
	void Update () {
        px = transform.position.x;
        px += (velocidade+velocidadeUP) * Time.deltaTime;
        transform.position = new Vector3(px,transform.position.y,transform.position.z); //Movimentação do obstaculo

        if (DestroyInst)
        {
            Destroy(transform.gameObject);
        }
        
        else if (px <= -5)
        {
            Destroy(transform.gameObject);
            
        }

        if(px < Player.transform.position.x && !scored)
        {
            if (!bateu)
            {
            scored = true;
            PlayerControlador.score = (PlayerControlador.score +1)+multiplicador;
            GerenciadorDesafio.score = (GerenciadorDesafio.score +1)+multiplicador;
            PlayerControlador.soundscore = true;
            contador++;
                if(contador >= 15)
                {
                    Dificuldade.ativa6 = true;
                    contador = 0;
                }
            }
            if (bateu)
            {
                Destroy(transform.gameObject);
            }
          

        }
	}
}
