using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ordas : MonoBehaviour {

	public int scoreParaOrdas = 0;
	public  Canvas telaOrda ;
	public int multiplicaOrda = 0;
	public GameObject score;
	public float cont = 0;
	public float contMax = 2;
	public int orda = 0;
	public bool mostrar = false;
	Text texto;
	void Start () {
		texto = GetComponent <Text> ();
		telaOrda.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {


		scoreParaOrdas = score.GetComponent <Pontos> ().p;



		if (scoreParaOrdas >= multiplicaOrda) {
			


				multiplicaOrda += 5;
			orda++;
			mostrar = true;
		
		} 



		if (mostrar) {

			cont += Time.deltaTime;
			telaOrda.enabled = true;
			texto.text = "Orda: : " + orda;  
			if (cont >= contMax) {

				cont = 0;
				mostrar = false;

			}


		} else {
			telaOrda.enabled =false;
			mostrar = false;
		}

	
	}
}
