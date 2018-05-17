using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamerOver : MonoBehaviour {
    public Text Score, Recorde;
    public bool click;
    public static bool EstadoSom = true;
    public static bool SomCena = true;
    public AudioSource AudioMusica;
	void Start () {
        if (!SomCena)
        {
            DisableSom();
        }

        Score.text = PlayerPrefs.GetInt("Score").ToString();
        Recorde.text = PlayerPrefs.GetInt("Recorde").ToString ();
        PlayerControlador.ContScore = 0;
        ControleHP.Vidas = 3;
        ControleHP.bateu = false;
        MoveTexture.velocidadeCeuUP = 0;
        MoveTexture.velocidadeSoloUP = 0;
        SpawControler.intervaloSpawUP = 0;
        MoverObjeto.velocidadeUP = 0;
        GerenciadorDesafio.score = 0;
        Relogio.liga = false;
        MoverObjeto.multiplicador = 0;


    }
public void Restart(bool clicked)
    {
        if (clicked)
        {
            SceneManager.LoadScene("Matekids");
        }
    }	
public void Home(bool clicked)
    {
        if (clicked)
        {
            SceneManager.LoadScene("Inicio");
        }
    }
    void DisableSom()
    {
        AudioMusica.Stop();
    }
}
