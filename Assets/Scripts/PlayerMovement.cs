using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D _rb;
	private Animator _an;
	public GameObject platform;
	
	public float speed = 10f;
	public float jumpForce = 400f;
	public float maxVelocityX = 4f;

	private bool _grounded;
	private bool idle = true;

	void Start () {
		_rb = GetComponent<Rigidbody2D> ();	
		_an = GetComponent<Animator> ();	
	}
	
	void FixedUpdate () {
		var force = new Vector2 (0f, 0f);
		float moveHorizontal = Input.GetAxis ("Horizontal");

		var absVelX = Mathf.Abs (_rb.velocity.x);
		var absVelY = Mathf.Abs (_rb.velocity.y);
		
		_grounded = absVelY == 0;

		if (absVelX < maxVelocityX) {
			force.x = speed * moveHorizontal;
		}

		if (_grounded && Input.GetButton ("Jump")) {
			_grounded = false;
			force.y = jumpForce;
			_an.SetInteger ("AnimState", 1);
			idle = false;
		}

		_rb.AddForce (force);

		if (moveHorizontal > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
			if (_grounded) {
				_an.SetInteger ("AnimState", 2);
			}
			idle = false;
		} else if (moveHorizontal < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
			if (_grounded) {
				_an.SetInteger ("AnimState", 2);
			}
			idle = false;
		} else if (_grounded){
			_an.SetInteger ("AnimState", 0);
			
			if(!idle){
				DestroyPlatformsBelow();
				CreateNewPlatforms();
				idle = true;	
			}
		}
	
	}
	
	void DestroyPlatformsBelow(){
		var platforms = GameObject.FindGameObjectsWithTag ("Platform");
		
		if(platforms.Length <= 0)
			return;
		
		foreach(var p in platforms){
			if(p == platform)
				continue;
			if(p.transform.position.y < transform.position.y - 10){
				Destroy(p);
			}
		}
	}
	
	void CreateNewPlatforms(){
		var newPlatform = Instantiate(platform, new Vector3(platform.transform.position.x, platform.transform.position.y + 1.25f, 0), Quaternion.identity);
		
		platform = newPlatform;
		
	}
}