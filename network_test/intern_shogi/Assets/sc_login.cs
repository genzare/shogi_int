using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sc_login : MonoBehaviour {

	[SerializeField] GameObject inputcanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void pushlogin(){
		string ipaddress="0";

		inputcanvas.SendMessage ("Saveip");
		Debug.Log (ipaddress);
	}
}

