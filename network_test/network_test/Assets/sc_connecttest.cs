using UnityEngine;
using System.Collections;

public class sc_connecttest : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		StartCoroutine ("Testconnect");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator Testconnect(){
		Debug.Log ("test1");
		string url = "https://www.google.co.jp/webhp?hl=ja#hl=ja&q=hogehoge";
		WWW www = new WWW(url);
		yield return www;
		Debug.Log(www.text);
		
		
	}
	
}
