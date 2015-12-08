using UnityEngine;
using System.Collections;

public class sc_connect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator Connect_get(){
		Debug.Log ("test1");
		string url = "http://192.168.33.11:3000/users/login";
		WWW www = new WWW (url);
		yield return www;
		Debug.Log(www.text);
		
		
	}
	
}




