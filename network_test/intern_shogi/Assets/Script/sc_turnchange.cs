using UnityEngine;
using System.Collections;

public class sc_turnchange : MonoBehaviour {
	[SerializeField]GameObject timestopper;
	[SerializeField]GameObject connect;
	public string state;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ChangeTurn(){
		if(state=="playing"){
			timestopper.SetActive(true);
			connect.GetComponent<sc_connect> ().Start_get (sc_connect.Get.CHECK);
			state="waiting";
		}
		else{
			timestopper.SetActive(false);
			state="playing";
		}

	}
}
