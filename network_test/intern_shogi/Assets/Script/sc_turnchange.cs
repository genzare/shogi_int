using UnityEngine;
using System.Collections;

public class sc_turnchange : MonoBehaviour {
	[SerializeField]GameObject timestopper;
	[SerializeField]GameObject connect;
	string turn;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Start_check(){
		if (sc_connect.lastplayer_check) {
			turn = "another turn";
		}
		else turn="myturn";	
	}

	public void ChangeTurn(){
	
		if(turn=="myturn"){
			Debug.Log(turn);
			timestopper.SetActive(true);
			connect.GetComponent<sc_connect> ().Start_get (sc_connect.Get.CHECK);
			turn="another turn";
		}
		else{
			Debug.Log(turn);
			timestopper.SetActive(false);
			turn="myturn";
		}

	}
}
