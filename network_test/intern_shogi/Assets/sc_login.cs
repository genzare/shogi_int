using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sc_login : MonoBehaviour {

	public GameObject inputcanvas;
	public GameObject connect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pushlogin(){

		string ipaddress="0";
		string playername;
		string roomno;
		ipaddress=inputcanvas.GetComponent<sc_saveinput>().saveip;
		playername=inputcanvas.GetComponent<sc_saveinput>().savename;
		roomno=inputcanvas.GetComponent<sc_saveinput>().saveroomno;

		Debug.Log (ipaddress);
		Debug.Log (playername);
		Debug.Log (roomno);
		int roomno_int = int.Parse (roomno);
		connect.GetComponent<sc_connect> ().StartCoroutine(connect.GetComponent<sc_connect> ().Connect_post(ipaddress,playername,roomno_int));

	}
}

