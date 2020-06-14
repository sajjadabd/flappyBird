using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	public Text text;
	//string ColliderName  = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		//string name = hit.gameObject.name;
		if (hit.gameObject.tag == "enemy") {

			//print (name);
			FindObjectOfType<birdControl> ().score++;
			text.text = "Score : " + FindObjectOfType<birdControl>().score.ToString();
		}

		//ColliderName = hit.gameObject.name;

	}

}
