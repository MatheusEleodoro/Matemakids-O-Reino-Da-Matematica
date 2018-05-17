using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour {

    private Material c_material;
    public float velocidadeSolo, velocidadeCeu;
    public static float velocidadeSoloUP=0, velocidadeCeuUP=0;
    public int id = 0;
    private float offset;


	void Start () {
        c_material = GetComponent<Renderer>().material;
	}
	
	
	void Update () {

        if (id == 1)
        {
          offset += (velocidadeSolo+velocidadeSoloUP) * Time.deltaTime;
          c_material.SetTextureOffset("_MainTex", new Vector2(offset,0));
        }
        if (id == 2)
        {
           offset += (velocidadeCeu+velocidadeCeuUP) * Time.deltaTime;
           c_material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }

	}
}
