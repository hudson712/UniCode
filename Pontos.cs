using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Pontos : MonoBehaviour {

	public static int pontos;
	public int p ;
	Text texto;

	public void acrescenta(){

		pontos ++;
	}

	void Start () {
		texto = GetComponent <Text> ();

	}
	

	void Update () {
		p = pontos;
		texto.text = "Pontos: " + pontos;  
	}
}
