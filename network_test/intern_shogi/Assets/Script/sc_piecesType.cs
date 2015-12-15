using UnityEngine;
using System.Collections;

public class sc_piecesType : MonoBehaviour {
	public bool can_move;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Getsprite(string name, bool owner, bool promote){
		string s_owner, s_promote;
		if (owner ^ sc_connect.lastplayer_check)
			s_owner = "1";
		else
			s_owner = "0";
		if (promote)
			s_promote = "1";
		else
			s_promote = "0";
		Sprite test =Resources.Load<Sprite> ("60x64/"+name+s_owner+s_promote);
		this.gameObject.AddComponent<SpriteRenderer> ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite =test;

	}



}
