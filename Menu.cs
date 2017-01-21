using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {




	 public void sair(){
		Application.Quit ();

	}

	public void start(){
		
		Application.LoadLevel ("QuaseLegal_6.1");
	


	}

	public void reStart(){

	
		Application.LoadLevel ("Menu");


	}

	public void instrucoes (){

		Application.LoadLevel ("intrucoes");
	}

	public void voltarMenu (){
		Application.LoadLevel ("Menu");
	}

	public void comandos (){
		Application.LoadLevel ("comandos");
	}



}
