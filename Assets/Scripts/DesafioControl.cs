using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesafioControl : MonoBehaviour {
    
    private float PainelY, Boty;
    private int opc=1,Alternativa, RespostaCerta;
    private bool ativaDesafio = true, DesativaDesafio = false;
    public Text txtValor1, txtValor2, txtOperacao , txtBotOpc1,txtBotOpc2,txtBotOpc3;
    public GameObject FundoPainel, BotOpc1, BotOpc2, BotOpc3, Score, Spaw, Valor1, Valor2, Operador;
    public float velocidadePainel;
    public static bool Active =false;
    public static float py = 0.349f;
    public static int complexidade = 0;
    private float screenWidth, screenHeight;


    void Start () {

        screenWidth = Screen.width;
        screenHeight = Screen.height;

        if(screenWidth ==1440 && screenHeight == 2960)
        {
            py = 0.399f;
        }
           
          
	}


    void Update()
    {

        if (Active)
        {
            PainelY = FundoPainel.transform.position.y;
            if (PainelY >= py)
            {
                PainelY = FundoPainel.transform.position.y;
                PainelY -= velocidadePainel * Time.deltaTime;
                FundoPainel.transform.position = new Vector3(FundoPainel.transform.position.x, PainelY, FundoPainel.transform.position.z); //Movimentação do Painel
            }
            if (PainelY <= py)
            {
                BotOpc1.SetActive(true);
                BotOpc2.SetActive(true);
                BotOpc3.SetActive(true);
                Valor1.SetActive(true);
                Valor2.SetActive(true);
                Valor2.SetActive(true);
                Operador.SetActive(true);
                Score.SetActive(false);
                Spaw.SetActive(false);
                MoverObjeto.DestroyInst = true;
                if (Alternativa == 4)
                {
                    DesativaDesafio = true;

                }
                if (ativaDesafio && Alternativa != 4)
                {
                    if (DesativaDesafio)
                    {
                        opc = 1;
                        DesativaDesafio = false;
                    }
                    Desafio(opc);
                }


                
                if (DesativaDesafio && Alternativa == 4)
                {
                    GerenciadorDesafio.recom = true;
                    ativaDesafio = false;

                    DisableDesafio();
                    Alternativa = 0;
                    
                    opc = 1;
                }


            }

        }else if (!Active && !Transition.disableCol)
        {
            BotOpc1.SetActive(false);
            BotOpc2.SetActive(false);
            BotOpc3.SetActive(false);
            Valor1.SetActive(false);
            Valor2.SetActive(false);
            Valor2.SetActive(false);
            Operador.SetActive(false);
            Score.SetActive(true);
            Spaw.SetActive(true);
            FundoPainel.transform.position = new Vector3(transform.position.x, 15, transform.position.z);
            MoverObjeto.DestroyInst = false;
        }
  
    }
 
    //ALGOTIMO PARA ESCOLHA DE NUMEROS, E OPERAÇÕES
   public void Desafio(int opc)
    {
        int num1 = 0, num2=0,num3 = 0, operacao=0, Resposta=0, selectBot=0;
        
        operacao = opc;
        selectBot = Random.Range(1, 3);
        

        switch (operacao)
        {

            case 1:
                txtOperacao.text = "+";

                num1 = Random.Range(1+complexidade, 20+complexidade);
                txtValor1.text = num1.ToString();

                num2 = Random.Range(1+complexidade, 20 + complexidade);
                txtValor2.text = num2.ToString();
                
                Resposta = num1 + num2;
                break;

            case 2:
                txtOperacao.text = "-";

                num1 = Random.Range(1 + complexidade, 20 + complexidade);
                num2 = Random.Range(1 + complexidade, 20 + complexidade);
                
                if (num1 < num2)
                {
                    num3 = num1;
                    num1 = num2;
                    num2 = num3;
                }//Inverte numero valor 1 com 2 se 1 for menos que 2;
                  txtValor1.text = num1.ToString();
                  txtValor2.text = num2.ToString();
                  Resposta = num1 - num2;
                break;
            case 3:
                txtOperacao.text = "x";

                num1 = Random.Range(0 + complexidade, 9 + complexidade);
                num2 = Random.Range(0 + complexidade, 9 + complexidade);
                
                txtValor1.text = num1.ToString();
                txtValor2.text = num2.ToString();
                Resposta = num1 * num2;
                break;
            case 4:
                txtOperacao.text = "/";

                num1 = Random.Range(2 + complexidade, 10 + complexidade);
                num2 = Random.Range(1 + complexidade, 10 + complexidade);

                if (num1 < num2)
                {
                    num3 = num1;
                    num1 = num2;
                    num2 = num3;
                }//Inverte numero valor 1 com 2 se 1 for menos que 2;

                if ((num1 % num2) >0 )
                {

                    while ((num1 % num2)>0)
                    {
                        num1 = Random.Range(1 + complexidade, 10 + complexidade);
                        num2 = Random.Range(1 + complexidade, 10 + complexidade);
                    }
                }
                txtValor1.text = num1.ToString();
                txtValor2.text = num2.ToString();

                Resposta = num1 / num2;

                break;

                // 1 OPERAÇÂO É SOMA
                // 2 OPERACAO É SUBTRAÇÃO
                // 3 OPERAÇÃO É MULTICAÇÃO
                // 4 OPERAÇÃO É DIVISÃO

        } //Seletor de OPERAÇÃO

        
        switch (selectBot)
        {
            
            case 1:
                txtBotOpc1.text = Resposta.ToString();               
                txtBotOpc2.text = (num3 = Random.Range(Resposta-2,Resposta+10)).ToString();
                if(num3 == Resposta || num3 < 0)
                {
                    while(num3 == Resposta || num3 < 0)
                    {
                        txtBotOpc2.text = (num3 = Random.Range(Resposta - 2, Resposta + 10)).ToString();
                    }
                }
                txtBotOpc3.text = (num3 = Random.Range(Resposta-2,Resposta+10)).ToString();

                if (num3 == Resposta || num3 < 0)
                {
                    while (num3 == Resposta || num3 < 0)
                    {
                        txtBotOpc3.text = (num3 = Random.Range(Resposta - 2, Resposta + 10)).ToString();
                    }
                }

                RespostaCerta = 1;
                break;
            case 2:
                txtBotOpc2.text = Resposta.ToString();
                txtBotOpc1.text = (num3 = Random.Range(Resposta - 2, Resposta + 10)).ToString();

                if (num3 == Resposta || num3 < 0)
                {
                    while (num3 == Resposta || num3 < 0)
                    {
                        txtBotOpc1.text = (num3 = Random.Range(Resposta - 2, Resposta + 10)).ToString();
                    }
                }
                txtBotOpc3.text = (num3 = Random.Range(Resposta - 2, Resposta + 10)).ToString();
                if (num3 == Resposta || num3 < 0)
                {
                    while (num3 == Resposta || num3 < 0)
                    {
                        txtBotOpc3.text = (num3 = Random.Range(Resposta - 2, Resposta + 10)).ToString();
                    }
                }
                RespostaCerta = 2;    
                break;
            case 3:
                txtBotOpc3.text = Resposta.ToString();
                txtBotOpc1.text = (num3 = Random.Range(Resposta - 2, Resposta + 10)).ToString();

                if (num3 == Resposta || num3 < 0)
                {
                    while (num3 == Resposta || num3 < 0)
                    {
                        txtBotOpc1.text = (num3 = Random.Range(Resposta - 2, Resposta + 10)).ToString();
                    }
                }
                txtBotOpc2.text = (num3 = Random.Range(Resposta - 2, Resposta + 10)).ToString();
                if (num3 == Resposta || num3 < 0)
                {
                    while (num3 == Resposta || num3 < 0)
                    {
                        txtBotOpc2.text = (num3 = Random.Range(Resposta - 2, Resposta + 10)).ToString();
                    }
                }
                RespostaCerta = 3;
                break;
        } //Preenchedor de Botões com as Opções
        


       
        ativaDesafio=false;


    }
    void DisableDesafio()
    {
        Active = false;
    }
    public void ClickOpc1(bool clicked)
    {
        if (clicked)
        {
           int click = 1;
            if(click == RespostaCerta)
            {
                PlayerControlador.soundcerto = true;
                Debug.Log("Acertou ");
                GerenciadorDesafio.acertos++;
                Alternativa += 1;
                ativaDesafio = true;
            }
            else
            {
                PlayerControlador.sounderrado = true;
                Debug.Log("ERROU ");
                ativaDesafio = true;
                Alternativa += 1;
            }
            opc++;
        }
    }
    public void ClickOpc2(bool clicked)
    {
        if (clicked)
        {
            int click = 2;
            if (click == RespostaCerta)
            {
                PlayerControlador.soundcerto = true;
                Debug.Log("Acertou ");
                GerenciadorDesafio.acertos++;
                Alternativa += 1;
                ativaDesafio = true;
            }
            else
            {
                PlayerControlador.sounderrado = true;
                Debug.Log("ERROU ");
                ativaDesafio = true;
                Alternativa += 1;
            }
        }
        opc++;
    }
    public void ClickOpc3(bool clicked)
    {
        if (clicked)
        {
            int click= 3;

            if (click == RespostaCerta)
            {
                PlayerControlador.soundcerto = true;
                Debug.Log("Acertou ");
                GerenciadorDesafio.acertos++;
                Alternativa += 1;
                ativaDesafio = true;
            }
            else
            {
                PlayerControlador.sounderrado = true;
                Debug.Log("ERROU ");
                ativaDesafio = true;
                Alternativa += 1;
            }
        }
        opc++;
    }
}
