﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;



public  class sc_connect : MonoBehaviour {
	public static string IPaddress;
	public static string name;
	public static string role;
	public static int roomno;
	public static long play_id;
	public static long user_id;
	public static bool lastplayer_check;

	[SerializeField] GameObject gamestart;
	[SerializeField] GameObject gameboard;
	[SerializeField] GameObject turnchanger;
	public enum Post{ LOGIN, UPDATE, LOGOUT,};
	public enum Get{ STATE, USERS, CHECK, WINNER, PIECIES};

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Start_post(Post connect_kind){
		switch (connect_kind) {
		case Post.LOGIN:
			StartCoroutine ("post_login");
			break;
		}
	}

	public void Start_get(Get connect_kind){
		switch (connect_kind) {
		case Get.STATE:
			StartCoroutine ("get_state");
			break;
		case Get.USERS:
			StartCoroutine("get_users");
			break;
		case Get.CHECK:
			StartCoroutine("get_check");
			break;
		case Get.PIECIES:
			StartCoroutine ("get_pieces");
			break;
		}
	}


	IEnumerator get_state(){
		Debug.Log ("statein");
		Debug.Log (play_id);
		for(string state="waiting";state=="waiting";){
			yield return new WaitForSeconds (1.0f);
			string url = "http://"+IPaddress+":3000/plays/"+play_id+"/state";
			WWW www = new WWW (url);
			yield return www;
			Debug.Log(www.text);
			Dictionary<string,object> jsonData = MiniJSON.Json.Deserialize (www.text) as Dictionary<string,object>;
			state = (string)jsonData["state"];
		}
		gamestart.GetComponent<sc_startgame> ().chack_player ();
	}

	IEnumerator get_users(){
		Debug.Log ("userin");
		Debug.Log(play_id);
		string url = "http://"+IPaddress+":3000/plays/"+play_id+"/users";
		WWW www = new WWW (url);
		yield return www;
		Debug.Log(www.text);
		Dictionary<string,object> jsonData = MiniJSON.Json.Deserialize (www.text) as Dictionary<string,object>;
	
		Dictionary<string,object> first_player = (Dictionary<string,object>)jsonData["first_player"];
		long firstplayer_id=(long)first_player["user_id"];
		string firstplayer_name = (string)first_player ["name"];
		Dictionary<string,object> last_player = (Dictionary<string,object>)jsonData["last_player"];
		long lastplayer_id=(long)last_player["user_id"];
		string lastplayer_name = (string)last_player ["name"];
		if (lastplayer_id == user_id) {
			 lastplayer_check = true;
		}
		gamestart.GetComponent<sc_startgame> ().Lineup ();

		Debug.Log (firstplayer_id);
		Debug.Log (firstplayer_name);
		Debug.Log (lastplayer_id);
		Debug.Log (lastplayer_name);
	}

	IEnumerator get_check(){
		Debug.Log ("checkein");
		for(string state="waiting";state=="waiting";){
			yield return new WaitForSeconds (1.0f);
			string url = "http://"+IPaddress+":3000/plays/"+play_id;
			WWW www = new WWW (url);
			yield return www;
			Debug.Log(www.text);
			Dictionary<string,object> jsonData = MiniJSON.Json.Deserialize (www.text) as Dictionary<string,object>;
			long turn_count = (long)jsonData["turn_count"];
			long watcher_count = (long)jsonData["watcher_count"];
			long turn_player = (long)jsonData["turn_player"];
			state = (string)jsonData["state"];
		}

		turnchanger.GetComponent<sc_turnchange> ().ChangeTurn ();
	}


	IEnumerator get_pieces(){
		Debug.Log ("pieces");
		string url = "http://"+IPaddress+":3000/plays/"+play_id+"/pieces";
		WWW www = new WWW (url);
		yield return www;
		Debug.Log(www.text);
		Dictionary<string,object> jsonData = MiniJSON.Json.Deserialize (www.text) as Dictionary<string,object>;
		GameObject[] pieces = new GameObject[40];
		for (int np=0; np<40; np++) {
			pieces[np]=new GameObject("pieces"+np);
			pieces[np].AddComponent<sc_pieces>();
			pieces[np].AddComponent<BoxCollider>();
			sc_pieces s_piece;
			s_piece = pieces[np].GetComponent<sc_pieces> ();
			Debug.Log(np.ToString());
			Dictionary<string,object> d_piece = (Dictionary<string,object>)jsonData [(np+1).ToString()];
			s_piece.name = (string)d_piece ["name"];
			long owner = (long)d_piece ["owner"];
			if(user_id ==owner) s_piece.owner=true;
			s_piece.posx = (long)d_piece ["posx"];
			s_piece.posy = (long)d_piece ["posy"];
			s_piece.promote = (bool)d_piece ["promote"];
		}


		gamestart.GetComponent<sc_startgame> ().Lineup ();

	}

	void SavePieceData(Dictionary<string,object> jsonData){


	}


	IEnumerator post_login(){
		string url = "http://" + sc_connect.IPaddress + ":3000/users/login";
		WWWForm form = new WWWForm ();
		form.AddField ("name", sc_connect.name);
		form.AddField ("room_no", sc_connect.roomno);
		WWW www = new WWW (url, form);
		yield return www;
		Debug.Log (www.text);
		Dictionary<string,object> jsonData = MiniJSON.Json.Deserialize (www.text) as Dictionary<string,object>;
		user_id = (long)jsonData["user_id"];
		play_id = (long)jsonData["play_id"];
		string state = (string)jsonData["state"];
		string role = (string)jsonData["role"];
		Debug.Log(play_id);

		Application.LoadLevel(1);

	}
}

	





