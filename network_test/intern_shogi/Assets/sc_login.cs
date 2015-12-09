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

		sc_connect.IPaddress=inputcanvas.GetComponent<sc_saveinput>().saveip;
		sc_connect.name=inputcanvas.GetComponent<sc_saveinput>().savename;
		sc_connect.roomno=int.Parse(inputcanvas.GetComponent<sc_saveinput>().saveroomno);

		Debug.Log (sc_connect.IPaddress);
		Debug.Log (sc_connect.name);
		Debug.Log (sc_connect.roomno);
//		int roomno_int = int.Parse (roomno);
		connect.GetComponent<sc_connect> ().Start_post (sc_connect.Post.LOGIN);
	
		//connect.GetComponent<sc_connect> ().StartCoroutine(connect.GetComponent<sc_connect> ().Connect_post(ipaddress,playername,roomno_int));



	}

	

}

