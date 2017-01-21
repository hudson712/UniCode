using UnityEngine;
using System.Collections;

public class CubeGunBehaviuor : MonoBehaviour {

	// Use this for initialization

	public BulletBehaviuor bala;
	public GameObject playerr;
	public Animator animaTiro;
	//fazendo o tempo para cada tiro 
	private float tempoDeTiro = 0.6f;
	// por causa do DeltaTime 
	public float contTempoDeTiro = 0;
	private bool TesteTiro = true;
	//----------------------------------
	public int Municao = 16;
	public int Pente = 64;
	private int inicMuncao;
	//--------------------------------
	public AudioClip AudioTiro;
	public AudioClip AudioReload;
	private AudioSource source;
	public bool pause = false;



	public int pa2 (){


		return this.Pente; 

	}

	public  int pa (){


		return this.Municao; 

	}

	void Start () {
		inicMuncao = Municao;
		/// precisa disso para emitir o audio
		source = GetComponent <AudioSource> ();

	

	}
	
	// Update is called once per frame
	void Update () {
		pause = playerr.GetComponent <Player> ().pause;
		if (!pause) {

			if (Pente > 64) {
				Pente = 64;
			}
			// testando o TesteTiro para dar o tempo de cada tiro
			if (TesteTiro == false) {
			
				contTempoDeTiro += Time.deltaTime;

				if (contTempoDeTiro > tempoDeTiro) {

					contTempoDeTiro = 0;
					TesteTiro = true;
				}

			}
			// Detectando Botão 1 do mouse
			if (Input.GetButtonDown ("Fire1") && TesteTiro && Municao > 0) {
				//chamando a bala para atira 
				Instantiate (bala, transform.position, transform.rotation);
				//fazendo a animação de tiro
				animaTiro.SetInteger ("teste2", 1);
				TesteTiro = false;
				Municao--;
				source.PlayOneShot (AudioTiro);
			} else {

				//zerando animaão de tiro
				animaTiro.SetInteger ("teste2", 0);
			}



			//Detectando botão R do teclado
			if (Input.GetKeyDown ("r")) {
			
				if (Municao >= 0) {
					TesteTiro = false;	
					if (Municao < inicMuncao) {
					
						int tempMunicao = inicMuncao - Municao;
						if (tempMunicao >= Pente)
							tempMunicao = Pente;
						Municao += tempMunicao;
						Pente -= tempMunicao;
						if (Pente > 0) {
							//Fazendo animação de reload

							animaTiro.SetInteger ("teste", 2);
							source.PlayOneShot (AudioReload);
						}
					}


				}




			} else {
				//zerando animação de reload
				animaTiro.SetInteger ("teste", 0);

			}

	
		}

	}
}
