using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class mostrarBalas : MonoBehaviour {
	Text balasMostrar;
	public int Municao ;
	public int Pente ;
	public GameObject player;
	// Use this for initialization
	void Start () {
		balasMostrar = GetComponent <Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		Municao = player.GetComponent <CubeGunBehaviuor> ().Municao;
		Pente = player.GetComponent <CubeGunBehaviuor> ().Pente;
		balasMostrar.text  =   Municao+"/"+Pente;

	}	
}
