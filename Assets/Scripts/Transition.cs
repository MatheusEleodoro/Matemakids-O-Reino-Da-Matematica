using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {
    public GameObject circulo, canvas,bg1,bg2,bg3,Score,Spaw;
    private float sy, sx;
    public static bool transition = false, fadein=false, fadeout=false,disableCol=false,Destroi=false;
    private int ID =0;

	void Start () {
		
	}
	
	void Update () {

        if (transition)
        {
            
            fadein = true;
            ID ++;
            if (ID > 3)
            {
                ID = 1;
            }
            transition = false;
        }
 



        if (fadein)
        {
            
            sx = circulo.transform.localScale.x;
            sy = circulo.transform.localScale.y;
            MoverObjeto.DestroyInst = true;
            disableCol = true;
            Score.SetActive(false);
            Spaw.SetActive(false);           
            canvas.SetActive(false);
            sx += 1.5f * Time.deltaTime;
            sy += 1.5f * Time.deltaTime;

            if(sx <= 1)
            {
                circulo.transform.localScale = new Vector3(sx, sy, 0);
            }
           else
            {
                if(ID==1)
                {
                    SpawControler.bg1 = false;
                    SpawControler.bg2 = true;
                    bg1.SetActive(false);
                    bg2.SetActive(true);
                    
                }else if (ID == 2)
                {
                    SpawControler.bg2 = false;
                    SpawControler.bg3 = true;
                    bg2.SetActive(false);
                    bg3.SetActive(true);
                }else if(ID == 3)
                {
                    SpawControler.bg3 = false;
                    SpawControler.bg1 = true;
                    bg1.SetActive(true);
                    bg3.SetActive(false);
                }
                Score.SetActive(true);
                Spaw.SetActive(true);
                fadein = false;
                fadeout = true;
                MoverObjeto.DestroyInst = false;
            }
           
        }


        if (fadeout)
        {

            sx -= 1f * Time.deltaTime;
            sy -= 1f * Time.deltaTime;

            if(sx > 0)
            {
                circulo.transform.localScale = new Vector3(sx, sy, 0);
            }
            else
            {
              
                circulo.transform.localScale = new Vector3(0, 0, 0);      
                canvas.SetActive(true);
                disableCol = false;
            }
        }


	}
}
