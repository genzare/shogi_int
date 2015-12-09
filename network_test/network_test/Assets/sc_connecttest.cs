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
		string url = "http://192.168.33.11:3000/plays/3/users";
		WWW www = new WWW(url);
		yield return www;
		Debug.Log(www.text);
		
		
	}
	
}
