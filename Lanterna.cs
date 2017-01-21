using UnityEngine;
using System.Collections;

public class Lanterna : MonoBehaviour {
	public AudioClip SomLanterna;
	private AudioSource source;
	public Light Luz;
	public float cont = 300;
	public float contMax = 0;
	public GameObject playerr;
	public bool pause = false;





	// Use this for initialization
	void Start () {
		source = GetComponent <AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		pause = playerr.GetComponent <Player> ().pause;
		if (!pause) {
			if (cont > 300) {
				cont = 300;

			}
			if (cont > 0 && Luz.enabled == true) {

				cont -= Time.deltaTime;

				if (cont < contMax) {

					cont = 0;
			

				}	
			}




			if (cont <= 0) {
				Luz.enabled = false;
			}



			if (Input.GetButtonDown ("Fire2") && cont > 0) {
				Luz.enabled = !Luz.enabled;
				source.PlayOneShot (SomLanterna);

		
			}
		}
	}
}


