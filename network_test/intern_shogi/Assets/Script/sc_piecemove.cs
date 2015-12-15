using UnityEngine;
using System.Collections;

public class sc_piecemove : MonoBehaviour {
	GameObject click_piece;
	bool activepieceexist;
	public long move_id;
	public long posx;
	public long posy;
	public bool promote;
	public long get_id;

	[SerializeField] GameObject connect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) { //駒動
			
			if(activepieceexist){ //場所決定
				Vector3 ClickMousePosition=(Input.mousePosition);
				Vector3 convertboardposition=ConvertCoodinate(ClickMousePosition);
				Debug.Log(convertboardposition);
				get_id=Getotherpiece(ClickMousePosition);
				posx=(long)convertboardposition.x;
				posy=(long)convertboardposition.y;
				promote =false;
				move_id=click_piece.GetComponent<sc_pieces>().pieceid;
				click_piece.GetComponent<sc_pieces>().Setpeices(convertboardposition.x,convertboardposition.y);
				Debug.Log(get_id);

				activepieceexist=false;
				connect.GetComponent<sc_connect> ().Start_post (sc_connect.Post.UPDATE);
}
			else{//駒決定
				Ray ray = new Ray ();
				RaycastHit hit = new RaycastHit ();
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				//マウスクリックした場所からRay？を飛ばし、オブジェクトがあればtrue
				if (Physics.Raycast (ray.origin, ray.direction, out hit, Mathf.Infinity) ) {
					Debug.Log (hit.collider.gameObject.name);
					if(hit.collider.gameObject.name!="timestopper"){
					click_piece = transform.FindChild (hit.collider.gameObject.name).gameObject;
					Debug.Log("Child is:" + click_piece.name);
					click_piece.GetComponent<sc_pieces>().AvtiveThis();
					activepieceexist=true;
					}
				}
			}
			
			
		}
	
	}

	Vector3 ConvertCoodinate(Vector3 mousePosition){
		Vector3 clickworldposition;
		clickworldposition = Camera.main.ScreenToWorldPoint(mousePosition);
		
		float convert_x =clickworldposition.x; //xの盤面座標だすよー
		convert_x-=2.7f;
		int count_x=0;
		while(convert_x<0){
			convert_x+=0.6f;
			count_x++;
		}
		
		float convert_y = clickworldposition.y;//つぎはｙの盤面座標だすよー
		convert_y -=2.925f;
		int count_y=0;
		Debug.Log(convert_y);
		while (convert_y<0){
			convert_y+=0.65f;
			count_y+=1;
		}
		Vector3 clickboardposition = new Vector3(count_x,count_y,0);
		
		Debug.Log(clickboardposition);
		
		return clickboardposition;
		
	}
	long Getotherpiece(Vector3 Checkpoint){
		long get_id = -1;
		Ray ray = new Ray ();
		RaycastHit hit = new RaycastHit ();
		ray = Camera.main.ScreenPointToRay (Checkpoint);
		//渡されたチェックポイントからRay？を飛ばし、オブジェクトがあればtrue
		if (Physics.Raycast (ray.origin, ray.direction, out hit, Mathf.Infinity)) {
			Debug.Log (hit.collider.gameObject.name);
			GameObject otherpiece = transform.FindChild (hit.collider.gameObject.name).gameObject;
			if (otherpiece != click_piece){
				get_id=otherpiece.GetComponent<sc_pieces>().pieceid;
				otherpiece.GetComponent<sc_pieces>().Setpeices(0,0);
			}
		}
		return get_id;	
	}


}
