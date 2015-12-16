using UnityEngine;
using System.Collections;

public class sc_mybullet : MonoBehaviour {
	
	
	public float shot_speed;
	
	public enum bullet_mode{left=0,center,right}
	public bullet_mode thisbullet;
	public Transform enemy_tran;
	[SerializeField] float bullet_wide=0.3f;
	
	
	// Use this for initialization
	void Start () {
		Invoke ("Anglarvar", bullet_wide);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
	
	void Anglarvar(){
		
		var diff = (enemy_tran.position - transform.position ).normalized;
		transform.rotation = Quaternion.FromToRotation(Vector3.up,  diff);
		
		
		switch (thisbullet) {
		case bullet_mode.left:
			this.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
			this.GetComponent<Rigidbody2D>().AddForce(transform.up*shot_speed,ForceMode2D.Impulse);
			break;
		case bullet_mode.right:
			this.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
			this.GetComponent<Rigidbody2D>().AddForce(transform.up*shot_speed,ForceMode2D.Impulse);
			break;
		}
		
		
		
	}
}
