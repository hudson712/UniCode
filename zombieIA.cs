using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class zombieIA : MonoBehaviour {
	// Código produzido Por GUTO: https://www.youtube.com/channel/UCPBHkllKEBr8vAMTldHXhGg

	private BulletBehaviuor Tiro;
	private Transform player;
	private List<GameObject> wayPointsList;

	public bool testeDano = false;
	public float timer=0;
	public float velocidade;
	public int vida = 100;
	public bool vivo= true;
	public Animator animaZombie;
	public float contMAX = 0.2f;
	public float cont = 0;
	public bool contTeste = false;

	public bool somNormalTest = true ;
	public float contNormalTet = 0;
	public float contMAXNormalTest = 3;


	public bool somAtacandoTest = false ;
	public float contAtacandoTet = 0;
	public float contMAXAtacandoTest = 1;


	public bool voltaTest = false ;
	public float contVoltaTet = 0;
	public float contMAXVoltaTest = 3;


	public AudioClip zombieMorrendo;
	public AudioClip zombieAtacando;
	public AudioClip zombieNormal;
	private AudioSource source;


	public float t = 0;
	private bool pontoTeste = false;


	// Use this for initialization

	void Start () {

		source = GetComponent <AudioSource> ();

		animaZombie.SetInteger("Atacando", 0);
		vida = 100;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		GameObject[] wayPoints = GameObject.FindGameObjectsWithTag ("wayPoint");
		wayPointsList = new List<GameObject> ();
		foreach (GameObject newWayPoint in wayPoints){
			wayPointsList.Add (newWayPoint);

		}
	}






	void OnTriggerEnter(Collider outro){

		if (outro.gameObject.tag == "Bala") {
			vida -= 45; 
			source.PlayOneShot (zombieMorrendo);
		}
		if (outro.gameObject.tag == "Player") {
			testeDano = true;
		


		} else {
			testeDano = false;
	
		}
	}





	void Update () {


		Vector3 novaPosicao = new Vector3 (0, -0.22f,0);


		if (vida <= 0) {


			pontoTeste = true;
			animaZombie.SetInteger("Atacando", 2);
			vivo = false;
			contTeste = true;

		} 
	

		if (contTeste) {

			cont += Time.deltaTime;

			if (cont >= contMAX) {

				Destroy (gameObject);
				Pontos f = new Pontos ();
				f.acrescenta ();
			}
		}



	if (voltaTest) {

			contVoltaTet += Time.deltaTime;

			if (contVoltaTet >= contMAXVoltaTest) {
				Vector3 direcao = (player.position - transform.position).normalized;
				transform.position -= direcao * 4;
				contVoltaTet = 0;


			}
		}


		if (somNormalTest) {

			contNormalTet += Time.deltaTime;

			if (contNormalTet >= contMAXNormalTest) {

				source.PlayOneShot (zombieNormal);
				contNormalTet = 0;

			}
		}

		if (somAtacandoTest) {

			contAtacandoTet += Time.deltaTime;

			if (contAtacandoTet >= contMAXAtacandoTest) {

				source.PlayOneShot (zombieAtacando);
				contAtacandoTet = 0;

			}
		}


		controleDistancia ();
	}




	void controleDistancia (){

		float distanciaAoPlayer = Vector3.Distance (transform.position,player.position);
		if (distanciaAoPlayer < 100 && distanciaAoPlayer > 4 && vivo == true) {
			Follow ();


		} 

		if (distanciaAoPlayer < 10 && distanciaAoPlayer > 0.5 && vivo == true) {

			if (vivo == true){
				animaZombie.SetInteger ("Atacando", 1);
				somAtacandoTest = true ;
				somNormalTest = false;
				voltaTest = true;




			}
		} else if (vivo == true){
			testeDano = false;
			somAtacandoTest = false ;
			somNormalTest = true;
			animaZombie.SetInteger("Atacando", 0);
			voltaTest = false;
		}



	}



	void Follow (){

		GameObject wayPoint = null;

		//checa se ha um colisor entre mim e o player V
		if (Physics.Linecast (transform.position, player.position)) {
			//chamar detecção de wayPoint
			wayPoint = FindBetterWay();
		} else {

			wayPoint = GameObject.FindGameObjectWithTag ("Player");
		}

		Vector3 Dir = (wayPoint.transform.position - transform.position).normalized;

		transform.position += Dir * Time.deltaTime * 5;
		transform.rotation = Quaternion.LookRotation (Dir);
	}




	GameObject FindBetterWay (){

		GameObject betterWay = null;
		float distancieBetterWay = Mathf.Infinity;

		foreach(GameObject go in wayPointsList){

			float distToWayPoint = Vector3.Distance (transform.position, go.transform.position);
			float distToWayPointToTarget = Vector3.Distance (go.transform.position, player.position);
			float distToTarget = Vector3.Distance (transform.position, player.position);
			bool wallBetween = Physics.Linecast (transform.position,go.transform.position);
			if ((distToWayPoint < distancieBetterWay) && (distToTarget > distToWayPointToTarget) && (!wallBetween)) {

				distancieBetterWay = distToWayPoint;
				betterWay = go;
			} else {
				bool wayPointToTargetCollision = Physics.Linecast (go.transform.position, player.position);
				if (wayPointToTargetCollision == false) {
					betterWay = go;

				}
			}
		}


		return betterWay;
	}





}
