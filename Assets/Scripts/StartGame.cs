using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    public AudioSource audio, AudioMusica;
    public AudioClip FalaAuberto;
    public bool Qualseunome ;
    public GameObject Objeto1, Objeto2,text;
    public static bool EstadoSom = true, SomCena = true;//Verifica Se o som Foi ligado ou desligado
    private bool ativa = true;
    private float sorteio;
    void Start() {
 

        sorteio = Random.Range(100, 1000);
                Debug.Log("sorteio =" + sorteio);
        if(sorteio%5!=0)
        {
            Objeto1.SetActive(true);
            Objeto2.SetActive(true);
            text.SetActive(true);
        }
        ControleHP.Vidas = 3;
        MoveTexture.velocidadeCeuUP = 0;
        MoveTexture.velocidadeSoloUP = 0;
        SpawControler.intervaloSpawUP = 0;
        MoverObjeto.velocidadeUP = 0;
        GerenciadorDesafio.score = 0;
        Relogio.liga = false;
        MoverObjeto.multiplicador = 0;
    }

    void Update() {
       
        if (!SomCena)
        {
            DisableSom();
        }
        else
        {
            if (ativa)
            {
                 EnableSom();
            }
           
        }
    }

    void AtivFalaAuberto()
    {
        Debug.Log("Chamou");
        audio.PlayOneShot(FalaAuberto);
        audio.volume = 1;
        Qualseunome = false;
    }

    public void DisableSom()
    {
        AudioMusica.Stop();
        ativa = true;
    }
    public void EnableSom()
    {
        AudioMusica.Play();
        ativa = false;
    }

    public void InitiGame(bool clicked)
    {
        if (clicked)
        {
            SceneManager.LoadScene("Matekids");
        }
    }

    public void InitiTutorial (bool clicked)
    {
        if (clicked)
        {
            SceneManager.LoadScene("Tutorial");
        }
    }

    public void InitiCreditos (bool clicked)
    {
        if (clicked)
        {
            SceneManager.LoadScene("Creditos");
        }
    }

    public void InitiInicio (bool clicked)
    {
        SceneManager.LoadScene("Inicio");
    }

    public void QualSeuNome(bool clicked)
    {
        if (clicked)
        {
            Qualseunome = true;
            AtivFalaAuberto();
            Debug.Log("click");
        }
    }
}
