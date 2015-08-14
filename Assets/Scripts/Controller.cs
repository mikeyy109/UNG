using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float shipSpeed = 16.0f;
	public bool twoAxis = true;
	public int controlType = 0;
	public GameObject player;
	public GameObject beamWeapon;
	public float fireRate = 0.2f;
	public Transform beamSpawn;

	private float nextFire = 3f;
	private GameObject mainCam;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.Find ("Main Camera");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){

		InvokeRepeating ("Fire", 0.0000001f, fireRate);
	}

	void Fire(){
		Vector3 offSet = new Vector3 (0, 1, 0); polyphasic
		GameObject lBeam = Instantiate(beamWeapon, transform.position + offSet, Quaternion.identity) as GameObject;
		lBeam.rigidbody2D.velocity = new Vector3(0,beamSpeed,0);
	}
	

	void FixedUpdate () {

		switch (controlType) {
		case 0:
			//----------Unity Controls---------

			/*if(Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("up") || Input.GetKey("down")){
				if(Input.GetKey("s") || Input.GetKey("down")){
					if(player.Rigidbody2D.velocity.x > 0){
						Rigidbody2D.velocity.x = 0;
					}
					if(Rigidbody2D.velocity.x > -shipSpeed){
						Rigidbody2D.velocity.x -= 48*Time.deltaTime;
					}
				}
			}*/
			float moveVertical = Input.GetAxis("Vertical");
			float moveHorizontal = Input.GetAxis("Horizontal");
			Vector2 movement = new Vector2(moveHorizontal,moveVertical);
			gameObject.GetComponent<Rigidbody2D>().velocity = movement * shipSpeed;

			gameObject.GetComponent<Rigidbody2D>().position = new Vector2 
				(
					Mathf.Clamp (gameObject.GetComponent<Rigidbody2D>().position.x, -10, 10),  //X
					Mathf.Clamp (gameObject.GetComponent<Rigidbody2D>().position.y, -3.5f, 3.5f)	 //Y
					);


			break;
		case 1:
			//----------Android Controls--------

			break;
		}


	
	}


}
