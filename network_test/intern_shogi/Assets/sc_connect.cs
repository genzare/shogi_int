using UnityEngine;
using System.Collections;

public  class sc_connect : MonoBehaviour {
	string ipaddress="11";
	public enum Post{ LOGIN, UPDATE, LOGOUT,};
	public enum Get{ STATE, USER, ID, WINNER, PIECIES};
	public GameObject login;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator Connect_get(){
		Debug.Log ("test1");
		string url = "http://"+ipaddress+":3000/users/login";
		WWW www = new WWW (url);
		yield return www;
		Debug.Log(www.text);

		
	}

	public IEnumerator Connect_post(string ipaddress, string name, int roomno){


		string url = "http://"+ipaddress+":3000/users/login";
		WWWForm form = new WWWForm();
		form.AddField("name", name);
		form.AddField("roomno", roomno);
		WWW www = new WWW(url, form);
		yield return www;
		Debug.Log(www.text);
		}

}
	





