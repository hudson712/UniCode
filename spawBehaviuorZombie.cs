using UnityEngine;
using System.Collections;

public class spawBehaviuorZombie : MonoBehaviour {


	public int pontosQuantia ;
	public Transform[] spawnPoints;


	public GameObject prefabInimigo;



	public bool podeSpawnar;

	public GameObject []controle ;
	//-------------------------------------------
	public GameObject objectPontos;
	public int pontos;
	public int muda =1;
	public int muda2=0;
	public GameObject objectOrdas;
	public int ordas;








	//------------------------------------------


	void Start () {


		podeSpawnar = true;
			
			for (int i = 0; i != 5 ; i++) {
				spawnInimigo ();	
			}




	
	}
	

	void Update () {



		controle = GameObject.FindGameObjectsWithTag ("Zombie");


		if (controle.Length > (ordas *2)) {

		
			podeSpawnar = false;


		} else {

			podeSpawnar = true;
		}

		

	pontos = objectPontos.GetComponent <Pontos> ().p;
		ordas = objectOrdas.GetComponent <ordas> ().orda;








		if ( podeSpawnar){
			muda++;
		for (int i = 0; i <= muda2; i++) {
			spawnInimigo ();	

		}
		muda2 += 2;
	}

	}






	private void spawnInimigo (){



		int randonSpawn = Random.Range (0, spawnPoints.Length -1);


	
		Instantiate (prefabInimigo, spawnPoints [randonSpawn].position, spawnPoints [randonSpawn].rotation);
		podeSpawnar = false;



	}





}
