using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public GameObject player, painel, objeto, mao, objeto2,texto1,texto2,texto3,texto4,icon;
    public Animator anim;
    private float py, velocidade = 2f;
    private int opc = 1;
    private bool skip = false;
    public static bool validaTuto = true;

    void Start () {
		
	}
	
	
	void Update () {


        if (opc==1)
        {
            py = transform.position.y;
            py -= velocidade * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, py, transform.position.z); 
            if(py <= 1)
            {
                anim.SetBool("Slide", true);
            }

            if(py <= -2)
            {
                anim.SetBool("Slide", false);
                transform.position = new Vector3(transform.position.x, 2, transform.position.z); 
            }
            

        }
        if (opc ==2)
        {
            anim.SetBool("Slide", false);
            if (validaTuto)
            {
             transform.position = new Vector3(transform.position.x, -2, transform.position.z);
                validaTuto = false;
            }


            py = transform.position.y;
            py += velocidade * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, py, transform.position.z);

            if (py >= 1.2)
            {
                anim.SetBool("Jump", true);
                player.transform.position = new Vector3(player.transform.position.x, -1.16f, player.transform.position.z);
            }

            if (py >= 2)
            {
                transform.position = new Vector3(transform.position.x, -2, transform.position.z);
                anim.SetBool("Jump", false);
                player.transform.position = new Vector3(player.transform.position.x, -2.427f, player.transform.position.z);
            }
          
        }
 
        if(opc == 3)
        {


            player.SetActive(false);

            objeto.SetActive(false);

            objeto2.SetActive(true);

            painel.SetActive(true);

            texto1.SetActive(true);


            if (!validaTuto)
            {
                transform.position = new Vector3(-0.45f, 3.88f, transform.position.z);
                validaTuto = true;
            }
            float px = transform.position.x;


            if (px<=0.6)
            {
                px = transform.position.x;
                px += (velocidade -1) * Time.deltaTime;
                transform.position = new Vector3(px, transform.position.y, transform.position.z);
            }
           if(px >= 0.6)
            {
                transform.position = new Vector3(-0.59f, transform.position.y, transform.position.z);
            }
        }
        if(opc == 4)
        {
            texto1.SetActive(false);
            texto2.SetActive(true);
        }
        if(opc == 5)
        {
            texto2.SetActive(false);
            texto3.SetActive(true);
        }
        if(opc == 6)
        {
            texto3.SetActive(false);
            texto4.SetActive(true);
        }
        if(opc > 6)
        {
            opc = 0;
            SceneManager.LoadScene("Inicio");
        }
     }

    public void Skip(bool clicked)
    {
        if (clicked)
        {
            opc = opc + 1;
        }
    }
}
