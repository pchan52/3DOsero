using UnityEngine;
using System.Collections;

public class PhotonManager : Photon.MonoBehaviour
{	
	public string objectName;
	bool host = true;
	void Start(){
		// Photonへの接続を行う
		PhotonNetwork.ConnectUsingSettings("0.1");
		// PhotonNetworkの更新回数のセット
		PhotonNetwork.sendRate = 30;
//		Debug.Log("network接続”);
	}
	/// <summary>
	/// ロビーに接続すると呼ばれるメソッド
	/// </summary>
	void OnJoinedLobby(){
		// ランダムでルームに入室する
		PhotonNetwork.JoinRandomRoom();
		Osero.instance.mycolor = StoneStatus.Status.Blue;
		print ("ロビー接続");
	}
	/// <summary>
	/// ランダムで部屋に入室できなかった場合呼ばれるメソッド
	/// </summary>
	void OnPhotonRandomJoinFailed(){
		// ルームを作成、部屋名は今回はnullに設定
		PhotonNetwork.CreateRoom(null);
		Osero.instance.mycolor = StoneStatus.Status.Red;
		print ("ルーム作成");
		ScoreManager.turn.text = "YOUR TURN";
		ScoreManager.animator.SetTrigger ("First_Red");
		host = false;
	}

	/// <summary>
	/// ルームに入室成功した場合呼ばれるメソッド
	/// </summary>
	void OnJoinedRoom(){
		
		print ("ルーム入室");
		PhotonNetwork.Instantiate ("EmptyPosition", Vector3.zero, Quaternion.identity, 0);
		if(host){
			ScoreManager.turn.text = "RIVAL TURN";
			ScoreManager.animator.SetTrigger ("First_Red");
		}
	}
	/// <summary>
	/// UnityのGameウィンドウに表示させる
	/// </summary>
	void OnGUI(){
		// Photonのステータスをラベルで表示させています
//		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	/// <summary>
	/// フォトンサーバーから切断した後に呼び出されます。
	/// </summary>
	void OnDisconnectedFromPhoton(){ 
		//接続が切れました
		print("disconnected");
	}

	void CreateRoom(){
		RoomOptions roomOptions = new RoomOptions ();
		roomOptions.maxPlayers = 2; //部屋の最大人数
		roomOptions.isOpen = true; //入室許可する
	}

}
