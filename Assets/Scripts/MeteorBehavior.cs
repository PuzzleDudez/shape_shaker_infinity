using UnityEngine;
using System.Collections;

public class MeteorBehavior : MonoBehaviour {

	float ran;
	float count = 0;
	bool shouldMove = true; 

	// Use this for initialization
	void Start () {

		ran = Random.Range (1,5);
		if (ran == 1) {
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
			gameObject.tag = "green"; 
		} else if (ran == 2) {
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
			gameObject.tag = "red";
		} else if (ran == 3) {
			gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			gameObject.tag = "cyan";
		} else {
			gameObject.GetComponent<Renderer> ().material.color = Color.magenta;
			gameObject.tag = "magenta"; 
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldMove) {
			Vector3 pos = transform.position;
			// move meteor toward origin
			transform.Translate (-pos * (Time.deltaTime), Camera.main.transform); // time controls speed
		}
	}

	void OnCollisionEnter2D(Collision2D coll) { 

		//if (coll.gameObject.tag == "planetoid")
			shouldMove = false; 

		if (this.tag == coll.gameObject.tag) { 
			count++;
			//Debug.Log (count);

			// if same colors collide, kill em
			Destroy (this.gameObject);
			Destroy (coll.gameObject);
		}
			
		if (coll.gameObject.tag != "planetoid") {

			var joint = gameObject.AddComponent<SpringJoint2D> ();
			joint.connectedBody = coll.rigidbody;
			joint.distance = 0.5f;		// make spring short
			joint.frequency = 1000000;	// minimum springiness

		}
	}
}
