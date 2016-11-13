using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {
	public Text result;
	public Text red;
	public Text red_score;
	public Text blue;
	public Text blue_score;
	public Text back_title;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim.GetComponent<Animator> ();
		anim.SetBool ("select_back", false);
		result.text = "The result is ...";
		red.text = "Red :";
		red_score.text = Osero.instance.red_stones_num.ToString ();
		red.text = "Blue :";
		red_score.text = Osero.instance.blue_stones_num.ToString ();
		back_title.text = "Back to Title";

	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 rayposition = transform.localPosition;
		//		rayposition.y += 0.5f;
		Ray ray = new Ray (rayposition, transform.forward); 
		var hit = new RaycastHit ();

		if (Physics.Raycast (ray, out hit)) {
			GameObject backtotitle = hit.collider.gameObject;

			if (backtotitle.tag == "back_to_title") {
				anim.SetBool ("select_back",true);
				StartCoroutine ("BacktoTitle");
			}
			anim.SetBool ("select_back", false);
		}
	}

	IEnumerator BacktoTitle(){
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene ("Title");
	}
}
