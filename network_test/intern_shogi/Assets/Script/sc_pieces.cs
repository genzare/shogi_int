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
		Setpeices (posx,posy);
	
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButtonDown(0)) {
			Ray ray = new Ray ();
			RaycastHit hit = new RaycastHit ();
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			//マウスクリックした場所からRay？を飛ばし、オブジェクトがあればtrue 
			if (Physics.Raycast (ray.origin, ray.direction, out hit, Mathf.Infinity)) {
				Debug.Log (hit.collider.gameObject.name);

			}
		}
	
	}

	void Setpeices(float posx, float posy){
		float masx = 0.6f;
		float masy = 0.65f;
		float basex = masx*4;
		float basey = masy*4;
	
		this.gameObject.transform.position =new Vector3 (basex-masx*(posx-1),basey-masy*(posy-1), 0);
	}


}
