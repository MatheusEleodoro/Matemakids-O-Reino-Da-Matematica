using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour {
    public GameObject botDisable, botEnable;
    private bool Disable,Enable;
	// Use this for initialization
	void Start () {
        if (!PlayerControlador.SomCena)
        {
            botDisable.SetActive(false);
            botEnable.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Disable)
        {
           botDisable.SetActive(false);
           botEnable.SetActive(true);
           GamerOver.SomCena = false;
           PlayerControlador.SomCena = false;
           StartGame.SomCena = false;
          
           Disable = false;
        }
        if (Enable)
        {
            
            botDisable.SetActive(true);
            botEnable.SetActive(false);
            GamerOver.SomCena = true;
            PlayerControlador.SomCena = true;
            StartGame.SomCena = true;
            Enable = false;
        }

	}

    public void DisableMusica()
    {
        Disable = true;
    }
    public void EnableMusica()
    {
        Enable = true;
    }
}
