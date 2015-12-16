using UnityEngine;
using System.Collections;

public class sc_playermove : MonoBehaviour {
	
	Vector3 mouse_siten;
	Vector3 player_base;
	Vector3 sandbox;
	Vector3 move_abso;
	
	
	int frame=0;
	[SerializeField] int shot_delay=3;
	[SerializeField] GameObject obj_bullet;
	[SerializeField] GameObject obj_enemy;
	public float shot_speed=15;
	// Use this for initialization
	void Start () {
		
		mouse_siten = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) { 
			Debug.Log (Input.mousePosition);
			mouse_siten = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			player_base = transform.position;
			
			
			
		}
		
		if (Input.GetMouseButton (0)) {

			move_abso = player_base - (mouse_siten - Camera.main.ScreenToWorldPoint (Input.mousePosition));
			move_abso.z = 0;	
			transform.position = move_abso;
			
			Shot_bullet();
			
		}
		
		
		if(Input.GetMouseButtonUp(0)){
			Debug.Log ("siten up");
			mouse_siten= new Vector3(0,0,0);
		}
		
		
	}
	
	
	void Shot_bullet(){
		frame++;
		if (frame % shot_delay == 0) {
			float create_x = this.transform.position.x;
			float create_y = this.transform.position.y;
			//真ん中
			GameObject new_bullet1=(GameObject)Instantiate(obj_bullet, new Vector3(create_x, create_y,0), Quaternion.identity);
			new_bullet1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,shot_speed),ForceMode2D.Impulse);
			new_bullet1.GetComponent<sc_mybullet>().thisbullet=sc_mybullet.bullet_mode.center;
			new_bullet1.GetComponent<sc_mybullet>().shot_speed= shot_speed;
			new_bullet1.GetComponent<sc_mybullet>().enemy_tran = obj_enemy.transform;
			//右
			GameObject new_bullet2=(GameObject)Instantiate(obj_bullet,new Vector3(create_x, create_y, 0), Quaternion.identity);
			new_bullet2.GetComponent<Rigidbody2D>().AddForce(new Vector2(shot_speed/2,shot_speed/2),ForceMode2D.Impulse);
			new_bullet2.GetComponent<sc_mybullet>().thisbullet=sc_mybullet.bullet_mode.right;
			new_bullet2.GetComponent<sc_mybullet>().shot_speed= shot_speed;
			new_bullet2.GetComponent<sc_mybullet>().enemy_tran = obj_enemy.transform;
			//左
			GameObject new_bullet3=(GameObject)Instantiate(obj_bullet, new Vector3(create_x, create_y, 0), Quaternion.identity);
			new_bullet3.GetComponent<Rigidbody2D>().AddForce(new Vector2(shot_speed*-1/2,shot_speed/2),ForceMode2D.Impulse);
			new_bullet3.GetComponent<sc_mybullet>().thisbullet=sc_mybullet.bullet_mode.left;
			new_bullet3.GetComponent<sc_mybullet>().shot_speed= shot_speed;
			new_bullet3.GetComponent<sc_mybullet>().enemy_tran = obj_enemy.transform;
		}
	}
}

