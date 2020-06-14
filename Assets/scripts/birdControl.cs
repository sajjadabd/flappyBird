using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class birdControl : MonoBehaviour {

	//public Text text;
	AudioSource audio;
	AudioSource dieAudio;
	public GameObject restartPanel;
	Animator anim;
	Rigidbody2D rigid;
	public float speed = 10f;
	public float jump = 10f;
	bool die = false;
	bool start = false;
	Touch t;

	public int score;

	//string ColliderName = "";

	bool itisAndroid = false;


	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		rigid.gravityScale = 0f;
		restartPanel.SetActive (false);
		//StartCoroutine (wait());
		audio = GetComponents<AudioSource>()[0];
		dieAudio = GetComponents<AudioSource> () [1];
	}

	void playWingAudio()
	{
		if (audio.isPlaying == true) {

		} else {

			audio.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (start == false) {
			#if UNITY_EDITOR
			if (Input.anyKeyDown) {
				start = true;
				rigid.gravityScale = 1.5f;

				audio.Play();
			}
			#endif

			#if UNITY_ANDROID
			if (Input.touchCount > 0) {
				start = true;
				rigid.gravityScale = 1.5f;

				audio.Play();
			}
			#endif
		}

		if (start == true && die == false) {

			//Invoke ("go", 2f);
			#if UNITY_EDITOR

				if (Input.GetKeyDown (KeyCode.W)) {
					
					playWingAudio();

					rigid.velocity = new Vector2 (rigid.velocity.x, jump);
					start = true;

				} else {
					go ();

				}

				if (rigid.velocity.y > 0) {
					transform.rotation = Quaternion.Euler (0, 0, 30);
				} else {
					transform.rotation = Quaternion.Euler (0, 0, -30);
				}

			#endif

			#if UNITY_ANDROID
				if ( Input.touchCount > 0 )
				{
					itisAndroid = true;

					playWingAudio();


					t = Input.GetTouch(0);
					if ( t.phase == TouchPhase.Began ) {
						rigid.velocity = new Vector2 (rigid.velocity.x, jump);
						start = true;

					} else {
						go ();

					}
				}
					
			#endif


			if (itisAndroid) {

				//print(rigid.velocity);
				if (rigid.velocity.y > 0) {
					transform.rotation = Quaternion.Euler (0, 0, 30);
				} else {
					transform.rotation = Quaternion.Euler (0, 0, -30);
				}

			}

		}


	}



	void go()
	{
		rigid.velocity = new Vector2 (speed , rigid.velocity.y);
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (2f);
	}


	void OnCollisionEnter2D(Collision2D hit)
	{
		if (die == false) {
			if (hit.gameObject.tag == "enemyDie" || 
				hit.gameObject.tag == "ground" ||
				hit.gameObject.tag == "ceil" ) {

				dieAudio.Play ();
				anim.SetBool ("die", true);
				die = true;

				restartPanel.SetActive (true);

			}
		}

	}


	public void restartLevel()
	{
		//FindObjectOfType<Test> ().sendRequest ();
		//FindObjectOfType<Test> ().ShowAd ();
		SceneManager.LoadScene ("main");

	}

	public void exit()
	{
		Application.Quit ();
	}




}
