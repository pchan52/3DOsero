//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//
//public class TitleController : MonoBehaviour {
//
//	float time_count;
//
//	// Use this for initialization
//	void Start () {
//		time_count = 0f;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		time_count += Time.deltaTime;
//	}
//
//	public void Osero(){
//		TitleRay.selectObj.SetActive (true);
//		if (time_count > 3f) {
//			time_count = 0;
//			StartFlash();
//			Invoke ("LoadScene", 1.0f);
//		}	
//	}
//
//
//	public void StartFlash(){
//		StartCoroutine ("Flash");
//	}
//
//	public void LoadScene(){
//		gameObject.transform.position += Vector3.forward * 1.2f;
//		if(	
//			SceneManager.LoadScene ("Osero");
//		}
//
//
//
//	IEnumerator Flash(){
//		while (true){
//			TitleRay.selectObj.SetActive (false);
//			yield return new WaitForSeconds(0.1f);
//
//			TitleRay.selectObj.SetActive (true);
//			yield return new WaitForSeconds (0.1f);
//		}
//	}
//}
//