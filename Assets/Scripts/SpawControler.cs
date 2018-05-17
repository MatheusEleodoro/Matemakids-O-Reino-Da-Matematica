using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawControler : MonoBehaviour {

    public GameObject Obstaculo_prefab,Obstaculo_prefab2; //Objeto a ser Spawnado
    
    public float intervaloSpaw, time; //Controle do Intervalo de Spaw
    public static float intervaloSpawUP = 0;
    private int posicao; //Para controle se obstaculo vem por cima ou por baixo aleatoriamente
   // private float py = -1.543f;
    public float posA, posB;
	void Start () {
        time = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time >= (intervaloSpaw+intervaloSpawUP))
        {

            time = 0;
            posicao = Random.Range(1, 100);



            if (posicao %2 == 0)
            {
                GameObject PrefabTemp = Instantiate(Obstaculo_prefab) as GameObject;
                PrefabTemp.transform.position = new Vector3(transform.position.x, posA, transform.position.z);
            }
            else
            {
                GameObject PrefabTemp = Instantiate(Obstaculo_prefab2) as GameObject;
                PrefabTemp.transform.position = new Vector3(transform.position.x, posB, transform.position.z);
            }

            
        }
	}
}
