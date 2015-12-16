using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sc_massage : MonoBehaviour {

	[SerializeField] GameObject connect;
	[SerializeField]  GameObject secletbutton;
	public GameObject textobject;
	public enum Windowtext{WIN,LOSE,ESCAPED,READY};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void WindowLogout(){
		connect.GetComponent<sc_connect> ().Start_post (sc_connect.Post.LOGOUT);
	}

	public void ChangeText(Windowtext textkind){
		switch (textkind) {
		case Windowtext.ESCAPED:
			textobject.GetComponent<Text> ().text = "相手が降参しました";
			break;
		case Windowtext.WIN:
			textobject.GetComponent<Text>().text="勝利！！";
			break;
		case Windowtext.LOSE:
			textobject.GetComponent<Text>().text="敗北……";
			break;
		case Windowtext.READY:
			textobject.GetComponent<Text>().text="Ready???";
			secletbutton.SetActive(true);
			break;
		}
	}
	public void StartSTG(){
		Application.LoadLevel(2);
	}

}
