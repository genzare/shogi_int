using UnityEngine;
using System.Collections;

public class sc_login : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		StartCoroutine ("Testconnect");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator Testconnect(){
		Debug.Log ("test1");
		string url = "http://192.168.33.11:3000/users/login";
		WWWForm form = new WWWForm();
		form.AddField( "name", "MyGameName" );
		form.AddField( "room_no", 1 );
		WWW www = new WWW (url, form);
		yield return www;
		Debug.Log(www.text);
		
		
	}
	
}
