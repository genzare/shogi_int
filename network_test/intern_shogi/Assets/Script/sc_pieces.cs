using UnityEngine;
using System.Collections;

public class sc_pieces : sc_piecesType {
	public string name;
	public bool owner;
	public long posx;
	public long posy;
	public bool promote;



	// Use this for initialization
	void Start () {

		Getsprite (name, owner, promote);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
