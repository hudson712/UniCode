using UnityEngine;
using System.Collections;

public class BulletBehaviuor : MonoBehaviour {

	public float speed = 20;
	public float timeToLive = 6;
	private float correntTimeToLive = 0;
	private Ray raioColider;
	private RaycastHit hit;
	public float alcance = 1500;
	public int dano = 45;

// Use this for initialization
	void Start () {
		
		raioColider = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		//Vector3 direcaoTiro = transform.TransformDirection (Vector3.forward);
		if (Physics.Raycast (raioColider, out hit, alcance)) {
			if (hit.rigidbody != null) {
				


			}

		}
	
	
	}



	void OnTriggerEnter(Collider outro){

		if (outro.gameObject.tag == "Zombie") {
			Destroy (gameObject);



			}
		}

	
	// Update is called once per frame
	void Update () {

		correntTimeToLive += Time.deltaTime;


	


		if (correntTimeToLive > timeToLive) 
			Destroy (gameObject);

		

		transform.Translate (Vector3.forward * speed);
		//transform.rotation = Quaternion.LookRotation (hit.point - transform.position);
	}
}
