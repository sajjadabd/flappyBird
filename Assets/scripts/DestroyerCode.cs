using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D hit)
	{
		//print ("Trigger");
		if (hit.gameObject.tag == "enemyDie") {

			Destroy (hit.gameObject);

			//print ("find enemy trigger");
		}

		if (hit.gameObject.tag == "ground") {

			Destroy (hit.gameObject);

			//print ("find enemy trigger");
		}

		if (hit.gameObject.tag == "ceil") {

			Destroy (hit.gameObject);

			//print ("find enemy trigger");
		}

	}

	/*
	void OnCollisionEnter2D(Collision2D hit)
	{
		print ("Collision");
		if (hit.gameObject.tag == "enemy") {

			Destroy (hit.gameObject);

			print ("find enemy collision");
		}
	}
	*/
}
