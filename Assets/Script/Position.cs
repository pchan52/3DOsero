using UnityEngine;
using System.Collections;

public class Position : Photon.MonoBehaviour {

	public int x;
	public int y;
	public int z;
	
	public Position(int x = -100, int y = -100, int z = -100) {
		this.x = x;
		this.y = y;
		this.z = z;
	}
	public void set_position(int x, int y, int z) {
		this.x = x;
		this.y = y;
		this.z = z;
	}
	public bool isequal(Position other) {
		return x == other.x && y == other.y && z == other.z;
	}
	public bool isequal(int x, int y, int z) {
		return this.x == x && this.y == y && this.z == z;
	}
	public void print() {
		print (x.ToString() + "," + y.ToString() + "," + z.ToString());
	}


	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			//データの送信
			print("sent");
			stream.SendNext(x);
			stream.SendNext (y);
			stream.SendNext (z);

		} else {
			print ("receive");
			int x = (int)stream.ReceiveNext();
			int y = (int)stream.ReceiveNext();
			int z = (int)stream.ReceiveNext();
			Position position = new Position (x, y, z);
			Osero.instance.set_stone (Osero.instance.get_stone_status (position));
			Osero.instance.changeturn ();
			position.print ();

		}
	}
}
