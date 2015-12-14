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
		Sprite test =Resources.Load<Sprite> ("60x64/" + name + owner + promote);
		this.gameObject.AddComponent<SpriteRenderer> ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = test;

	}

}
