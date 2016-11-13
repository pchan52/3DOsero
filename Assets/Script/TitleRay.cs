using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleRay : MonoBehaviour {

	float time_count;
	bool first_look = true;
	GameObject selectObj;
	AudioSource audiosource;
	public AudioClip[] select = new AudioClip[2];
	// Use this for initialization
	void Start () {
		time_count = 0f; 
		audiosource = gameObject.GetComponent<AudioSource> ();
		audiosource.PlayOneShot (select [0]);

	}

	// Update is called once per frame
	void Update () {

		Vector3 rayposition = transform.localPosition;
//		rayposition.y += 0.5f;
		Ray ray = new Ray (rayposition, transform.forward); 
		var hit = new RaycastHit ();


		if (Physics.Raycast (ray, out hit)) {
			GameObject title = hit.collider.gameObject;
			selectObj = title.transform.FindChild ("SelectObj").gameObject;
			if (title.tag == "osero") {
				if (first_look) {
					selectObj.SetActive (true);
					first_look = false;
				}
				time_count += Time.deltaTime;
				if (time_count >= 3.0f) {
					time_count = 0;
					audiosource.Stop ();
					StartFlash ();
					audiosource.PlayOneShot (select[1]);
					Invoke ("LoadScene", 3.0f);
				}
			} else {
				selectObj.SetActive (false);
				first_look = true;
				time_count = 0;
			}
		} else {
//			selectObj.SetActive (false);
			first_look = true;
			time_count = 0f;
		}
	}


	public void StartFlash(){
		StartCoroutine ("Flash");
	}

	public void LoadScene(){
		print ("aaa");
		SceneManager.LoadScene ("Main");
	}



	IEnumerator Flash(){
		while (true){
			selectObj.SetActive (false);
			yield return new WaitForSeconds(0.1f);

			selectObj.SetActive (true);
			yield return new WaitForSeconds (0.1f);
		}
	}
}