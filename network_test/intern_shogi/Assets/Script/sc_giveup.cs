using UnityEngine;
using System.Collections;

public class sc_giveup : MonoBehaviour {

	[SerializeField]GameObject connect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Giveup(){

		connect.GetComponent<sc_connect> ().Start_post (sc_connect.Post.LOGOUT);

	}
}
