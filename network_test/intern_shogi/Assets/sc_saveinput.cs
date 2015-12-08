using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sc_saveinput : MonoBehaviour {

	public InputField inputip;
	public InputField inputname;
	public InputField inputroomno;
	private string saveip;
	private string savename;
	private string saveroomno;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	string Saveip(){
		saveip = inputip.text;
		return saveip;
	}
	string Savename(){
		savename = inputname.text;
		return savename;
	}
	string Saveroomno(){
		saveroomno = inputroomno.text;
		return saveroomno;
	}
}
