using UnityEngine;
using System.Collections;

public class sc_startgame : MonoBehaviour {
	[SerializeField] GameObject connect;
	[SerializeField] GameObject maincamera;
	[SerializeField] GameObject timestopper;
	// Use this for initialization
	void Start () {
		connect.GetComponent<sc_connect>().Start_get (sc_connect.Get.STATE);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void chack_player(){
		connect.GetComponent<sc_connect> ().Start_get (sc_connect.Get.USERS);
	}
	public void Lineup(){
		connect.GetComponent<sc_connect> ().Start_get (sc_connect.Get.PIECIES);
		if (sc_connect.lastplayer_check) {
			maincamera.transform.Rotate (0, 0, 180);
		}
		startgame ();
	}
	void startgame(){
		if (sc_connect.lastplayer_check) {
			timestopper.SetActive(true);
			connect.GetComponent<sc_connect> ().Start_get (sc_connect.Get.CHECK);
		}

	}
	 
}


class chack_watcher{
	string play_state;
	//引っ張り出す
	void chack_watch(){
		play_state = sc_connect.role;
		if (play_state == "watcher") {
		 //画面ロック等観測者の処理
		}
	}
}