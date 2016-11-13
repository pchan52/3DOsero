using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager: MonoBehaviour {

	public Text red;
	public Text red_num;
	public Text white_num;
	public Text blue;
	public Text blue_num;
	public static Text turn;
	public Text tuen_sub;

	public static bool setanim = true;

	public static Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		turn = tuen_sub;
	}

	// Update is called once per frame
	void Update () {
		red.text = "Red: ";
		red_num.text = Osero.instance.red_stones_num.ToString ();
		blue.text = "Blue: ";
		blue_num.text = Osero.instance.blue_stones_num.ToString ();

		white_num.text = "White: " + Osero.instance.white_stones_num;

		if (Osero.instance.white_stones_num == 5) {
			red_num.enabled = false;
			blue_num.enabled = false;
		}

		if (Osero.instance.white_stones_num == 0) {
			StartCoroutine ("LoadLastScene");
		}

	}


	public static void RedtoBlue(){
		switch(Osero.instance.mycolor){
		case StoneStatus.Status.Red:
			ScoreManager.turn.text = "RIVAL TURN";
			animator.SetTrigger ("RTB");
			break;
		case StoneStatus.Status.Blue:
			ScoreManager.turn.text = "YOUR TURN";
			animator.SetTrigger ("RTB");
			break;
		}
	}

	public static void BluetoRed(){
		switch(Osero.instance.mycolor){
		case StoneStatus.Status.Red:
			ScoreManager.turn.text = "YOUR TURN";
			animator.SetTrigger ("BTR");
			break;
		case StoneStatus.Status.Blue:
			ScoreManager.turn.text = "RIVAL TURN";
			animator.SetTrigger ("BTR");
			break;
		}
	}

	IEnumerator LoadLastScene(){
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene ("GameOver");
	}

}

