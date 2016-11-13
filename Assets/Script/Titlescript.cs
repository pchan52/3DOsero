using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Titlescript : MonoBehaviour {
	//半径
	//	[SerializeField]
	//	private float _radius;

	public float radius;
	float x;
	float y;
	float z;



	void Update(){
		Deploy ();

	}

	//子を円状に配置する(ContextMenuで鍵マークの所にメニュー追加)
	[ContextMenu("Deploy")]
	private void Deploy(){

		//子を取得
		List<GameObject> childList = new List<GameObject> ();
		foreach(Transform child in transform) {
			childList.Add (child.gameObject);
		}

		//数値、アルファベット順にソート
		childList.Sort (
			(a, b) => {
				return string.Compare(a.name, b.name);
			}
		);

		//オブジェクト間の角度差
		float angleDiff = 360f / (float)childList.Count;


		//各オブジェクトを円状に配置
		for (int i = 0; i < childList.Count; i++) {
			Vector3 childPostion = childList [i].transform.position;
			float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
			Vector3 offset = new Vector3 (Mathf.Sin (angle), 0f,  Mathf.Cos (angle));
			childList [i].transform.position = offset * radius;
//			childList [i].transform.rotation = Quaternion.Euler(0f, 360f, 0f);
			Vector3 scale = childList[i].transform.localScale;
			scale.x = -1;
			childList [i].transform.localScale = scale;
				
			childList [i].transform.LookAt (transform.position);

		}
	}

}  
