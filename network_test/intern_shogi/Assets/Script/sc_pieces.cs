using UnityEngine;
using System.Collections;

public class sc_pieces : sc_piecesType {
	public string name;
	public bool owner;
	public long posx;
	public long posy;
	public bool promote;
	public long pieceid;




	// Use this for initialization
	void Start () {
		GetSprite (name, owner, promote);
		SetPeices (posx,posy);
	
	}
	
	// Update is called once per frame
	void Update () {



	
	}

	public void SetPeices(float posx, float posy){ //マスを座標に変換しつつ配置
		float masx = 0.6f;
		float masy = 0.65f;
		float basex = masx*4;
		float basey = masy*4;
	
		if (posy == 0){
			Debug.Log("motiIn");
			GameObject gameboard = GameObject.Find("gameboard");
			posx = gameboard.GetComponent<sc_gameboard>().motispace; //とった駒整列
			gameboard.GetComponent<sc_gameboard>().motispace++;
		}
		this.gameObject.transform.position =new Vector3 (basex-masx*(posx-1),basey-masy*(posy-1), 0);
	}

	public void AvtiveThis(){
		//アクティブかわかりやすい表示ほしかった

	}
	
}
