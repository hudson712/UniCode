using UnityEngine;
using System.Collections;

public class spawBehaviuorPilha : MonoBehaviour {

	//public GameObject pontosClass;
	public int pontosQuantia ;
	public Transform[] spawnPoints;
	//	public GameObject playerScript;

	public GameObject prefabInimigo;

	public float tempoSpawnMax = 10;
	public float tempoSpawn = 0;

	public bool podeSpawnar ;
	public GameObject []controle ;



	void Start () {
		podeSpawnar = true;

	}


	void Update () {


		controle = GameObject.FindGameObjectsWithTag ("Pilha");


		if (controle.Length >=1) {


			podeSpawnar = false;


		} else {

			podeSpawnar = true;
		}



		if (podeSpawnar) {
			tempoSpawn += Time.deltaTime;

		}
		if (tempoSpawn > tempoSpawnMax) {
			tempoSpawn = 0;
			spawnInimigo ();
			tempoSpawnMax = Random.Range (2.5f, 10);

		}




	}




	private void spawnInimigo (){



		int randonSpawn = Random.Range (0, spawnPoints.Length -1);



		Instantiate (prefabInimigo, spawnPoints [randonSpawn].position, spawnPoints [randonSpawn].rotation);
		podeSpawnar = false;



	}





}
