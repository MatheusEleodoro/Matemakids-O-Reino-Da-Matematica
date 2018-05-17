using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerControlador : MonoBehaviour
{
    //Declaração de variaveis 

    public Rigidbody2D PlayerRB; //Corpo do Personagem
    public Animator Anim; //controle das animações
    public int JumpForca;// força do pulo do player
    public static int RecepVidas;
    private bool checkvidas;

    private bool InitToque = false;
    private bool pulo, slide;
    private bool ControleDeChamada;

    public Transform Check_Chao; // Variaveis p/ verificaçao se player esta no chão ou não
    public bool check_c = false;
    private float chaoRadios = 0.2f;
    public LayerMask issoechao; //fim

    public float SlideTemp, TempTime; // P controle do tempo do slide
   

    public float sensibilidade = 20f;// sensibilidade do touch
    private bool validacao = true, validacao_aux2 = true, validacao_aux = false;
    private Vector2 pcima, pbaixo;// controle de direção touch
    public Transform colisor; // Sistema de Colisão

    public AudioSource audio,audioMusica; // Controle de Audio
    public AudioClip SoundJump, SoundSlide, SoundScore, SoundDano, SoundLife, SoundCerto, SoundErrado; // fim Controle de audio

    public static int score, ContScore; // Controle Pontuação
    public static bool soundscore, sounddano, soundlife, soundcerto, sounderrado, SomCena =true;
    public Text txtScore;
    public GameObject C1, C2, C3;
    private bool ativa = true;

    // Fim Declaração

    // Inicialização
    void Start()
    {
 

        Debug.Log("Jogo Iniciado");
        //Debug.Log(RecepVidas);
        score = 0;
        ContScore = 0;
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Score", score);
        C1.SetActive(true);
        C2.SetActive(true);
        C3.SetActive(true);
    }

 
    void Update()
    {
 
        CheckChao(); // Instancia Verificação constante se personagem esta no chão ou não
        txtScore.text = score.ToString();
        if (!SomCena)
        {
            DisableMusica();
        }
        else
        {
            if (ativa)
            {
              EnableMusica();
            }
          
        }
        if (sounddano)
            {
                AtivSoundDano();
            }//Som de Dano    

        if (soundscore)
         {
            AtivSoundPoint();
         } //Som de Score 

        if (soundlife)
        {
            AtivSound1up();
        }//Som life 1up

        if (soundcerto)
        {
            AtivSoundCerto();
        }//Som reposta certa

        if (sounderrado)
        {
            AtivSoundErrado();
        }// Som resposta errado

        if (!check_c)
        {
            ControleDeChamada = false;
        } //Validação para pulo


        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                pcima = touch.position;
                pbaixo = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {


                if (!InitToque && !ControleDeChamada)
                {
                 /* Debug.Log("Toque Iniciado");
                    Debug.Log("Toque Iniciado = " + InitToque);
                    Debug.Log("Controle de Chamada = " + ControleDeChamada);
                 */
                    pbaixo = touch.position;
                    CheckSwipe();

                }
                else
                {
                 /* Debug.Log("Toque Não Iniciado");
                    Debug.Log("Toque Iniciado = " + InitToque);
                    Debug.Log("Controle de Chamada = " + ControleDeChamada);
                    Debug.Log("Chão =" + check_c);
                    Debug.Log("Pulo =" + pulo);
                 */

                    if(!pulo && check_c)
                    {
                        ControleDeChamada = false; 
                    }
                
                }
            }
        } //Captura a posição do touch EIXO Y E EIXO X PARA CHECKSWIPE DA DIREÇÃO


    }

    
    //Incio CheckSwipe - FUNÇÃO QUE IDENTIFICA DIREÇÃO CIMA OU BAIXO PARA PASSAR A OS CONTROLADORES
    void CheckSwipe()
    {
        if (VerticalMove() > sensibilidade && VerticalMove() > HorizontalMove())
        {
            if (pbaixo.y - pcima.y > 0)
            { 
                OnControllerCima();
            }
            else if (pbaixo.y - pcima.y < 0)
            {
                OnControllerBaixo();
            }
            if (!pulo)
            {
                ControleDeChamada = false;
            }
            else if (pulo)
            {
                ControleDeChamada = true;
            }

        }

    }
    //Fim CheckWipe

    float VerticalMove()
    {
        return Mathf.Abs(pbaixo.y - pcima.y);
    }
    float HorizontalMove()
    {
        return Mathf.Abs(pbaixo.x - pcima.x);
    }
    void OnControllerCima()//REALIZA CONTROLE DE PULO DO PERSONAGEM
    {


        if (check_c && !pulo) // Bloqueio de Slide no AR, ou pulo constante
        {
            
            pulo = true;
            PlayerRB.AddForce(new Vector2(0, JumpForca));
            Anim.SetBool("Jump", pulo);
            
            TempTime = 0;
            audio.volume = 1;
            audio.PlayOneShot(SoundJump);
            if (slide)
            {
                
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.1f, colisor.position.z);
                slide = false;
                validacao_aux = true;
                validacao = true;
            } //Função Descer o Colisor
            else
            {
                validacao_aux = false;
            }

        }

        //Anim.SetBool("Jump", pulo); // Passa VERDADEIRO ou FALSO para as Animações dentro do Unity
    }
    void OnControllerBaixo()
    {
        if (check_c && !slide)
        {
           
            slide = true;
            audio.volume = 0.2f;
            audio.PlayOneShot(SoundSlide);

            if (validacao)
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.1f, colisor.position.z);
                validacao = false;
            } //Função Sumir Colisor 


        }
    }// REALIZA ATIVAÇÃO DO SLIDE DO PERSONAGEM TRANSFORMANDO VARIAVEL slide em TRUE

    void CheckChao() //Verifica se personagem esta no chão
    {

        check_c = Physics2D.OverlapCircle(Check_Chao.position, chaoRadios, issoechao); // Cria Bloco de Colisão na posição do personagem 

        if (check_c)// Verifica se ele esta no chao e se pode realizar o pulo
        {
            pulo = false;

        }


        if (slide == true && check_c == true)
        {

            if (TempTime >= SlideTemp)
            {
                TempTime = 0;

            }
            TempSlide();

        }  //Controle e Validação do Tempo de Slide

        if (Anim.GetBool("Jump") == true && check_c)
        {
            Anim.SetBool("Jump", false);
        }
        Anim.SetBool("Slide", slide);

    }
    void TempSlide()
    {

        if (slide == true)
        {
            if (TempTime < SlideTemp)
            {
                TempTime += Time.deltaTime;
                if (TempTime >= SlideTemp)
                {
                    slide = false;
                    if (!validacao_aux)
                    {
                        colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.1f, colisor.position.z);
                        validacao = true;
                    }

                }

            }


        }

    }// Função que Marca tempo de 1s de duração para o slide 
 
    void DisableMusica()
    {
        audioMusica.Stop();
        ativa = true;
    }

    void EnableMusica()
    {
        audioMusica.Play();
        ativa = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Inicio");
    }
    void OnTriggerEnter2D()
    {
        ControleHP.bateu = true;
        MoverObjeto.bateu = true;
       if (RecepVidas == 0)
        {
            PlayerPrefs.SetInt("Score", score);
            if (score > PlayerPrefs.GetInt("Recorde"))
            {
                PlayerPrefs.SetInt("Recorde", score);
            }
            SceneManager.LoadScene("Gameover");
        }
    }
    void AtivSoundPoint()
    {

        audio.PlayOneShot(SoundScore);
        audio.volume = 1;
        soundscore = false;

    }
    void AtivSoundDano()
    {
        audio.PlayOneShot(SoundDano);
        audio.volume = 1;
        sounddano = false;

    }
    void AtivSound1up()
    {
        audio.PlayOneShot(SoundLife);
        audio.volume = 1;
        soundlife = false;
    }
    void AtivSoundCerto()
    {
        audio.PlayOneShot(SoundCerto);
        audio.volume = 1;
        soundcerto = false;
    }
    void AtivSoundErrado()
    {
        audio.PlayOneShot(SoundErrado);
        audio.volume = 1;
        sounderrado = false;
    }
}