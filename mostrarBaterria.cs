using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class mostrarBaterria : MonoBehaviour {
	Text mostrarABaterria;
	public float bateria ;
	public GameObject lanterna;


	// Use this for initialization
	void Start () {
		mostrarABaterria = GetComponent <Text> ();

	}

	// Update is called once per frame
	void Update () {
		int value = (int)bateria;
		if (value < 0)
			value = 0;



		bateria = lanterna.GetComponent <Lanterna> ().cont;
		mostrarABaterria.text  =   "Bateria: "+value;





		
	}	
}
