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
	public void StartCheck(){
		if (sc_connect.lastplayer_check) {
			turn = "myturn";
		}
		else turn="another turn";	
	}

	public void ChangeTurn(){
	
		if(turn=="another turn"){
			Debug.Log(turn);
			timestopper.SetActive(true);
			connect.GetComponent<sc_connect> ().Start_get (sc_connect.Get.CHECK);
			turn="myturn";
		}
		else{
			Debug.Log(turn);
			timestopper.SetActive(false);
			turn="another turn";
		}

	}
}
