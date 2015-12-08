	using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sc_saveinput : MonoBehaviour {

	public InputField inputip;
	public InputField inputname;
	public InputField inputroomno;
	public string saveip;
	public string savename;
	public string saveroomno;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Saveip(){
		saveip = inputip.text;
	}
	public void Savename(){
		savename = inputname.text;
	}
	public void Saveroomno(){
		saveroomno = inputroomno.text;
	}
}
