using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {

	public bool vivo= true;
	public Transform euMesmo;
	public bool testeTempo = true;
	public float cont = 0;
	public float contMax = 4;
	public static int coracaoP = 10;
	public int coracao = 10;
	public bool mapaTeste = true;
	public bool pause = false;
	public Canvas menuPause ;
	public Slider coracaoSlider;
	public Canvas telaFim ;
	public bool comecaTudo = false;
	public int dano;
	public GameObject objectOrdas;
	public int ordas;



	// Use this for initialization
	void Start () {

		coracao = coracaoP;
		dano = 1;
		vivo = true;
	
	}




	void OnTriggerStay(Collider outro){

		if (outro.gameObject.tag == "Zombie") {
			//if (testeTempo) {
				comecaTudo = true;
				//	testeTempo = false;


			//}
		} else {
			comecaTudo = false;

		}
	
	}





















	public bool vidaSera (){

		return this.vivo;
	}



	public void voltarGame(){
		pause = false;
	}



	void Update () {



		ordas = objectOrdas.GetComponent <ordas> ().orda;

		


		if (comecaTudo) {

			if (testeTempo == false) {

				cont += Time.deltaTime;

				if (cont > contMax ) {

					cont = 0;
					testeTempo = true;

				}	

			}

			if (testeTempo) {
				print ("levo dano");
				coracao -= dano;
				coracaoP--;
				testeTempo = false;
			}

		}


		if (ordas > 4) {

			dano = 2;

		}


























		

		coracaoSlider.value = coracao;
		 

	






		//______________________________________




		if (vivo) {

			telaFim.enabled = false;



		} else if (!vivo){
	
			pause = true;


		}


		if (coracao <= 0) {




			vivo = false;

		} 



		if (Input.GetButtonDown ("Cancel")) {
			pause = !pause;

		}

		if (pause && vivo) {
			Time.timeScale = 0;
			menuPause.enabled = true;
			Cursor.visible = true; 
			Cursor.lockState = CursorLockMode.None;

		} else if(!pause && vivo){
			Time.timeScale = 1;
			menuPause.enabled = false;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		
		}else if(pause && !vivo){
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0;
			telaFim.enabled = true;
			Cursor.visible = true; 
		}

	}






}