using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollower2D : MonoBehaviour {

	private Transform target;
	public float boundsBottom = -4.5f;
	public float distance = 1.5f;

	public int platformCounter = 0;
	public Text PlatformCounterText;

	public Vector2 movementFromBase = new Vector2 (0.0f, 0.0f);
	public Vector2 baseLocation = new Vector2(0.0f, 0.0f);

	private float upperY = -3.0f;

	void Start () {
		platformCounter = 0;

		target = GameObject.FindWithTag ("Player").transform;

		baseLocation = new Vector2 (transform.position.x, transform.position.y);

		var platform = GameObject.FindWithTag ("Platform");

		for (var i = 1; i < 10; i++) {
			var newX = Random.Range (1000, 2258) / 1000.0f;

			Instantiate (platform, new Vector3 (newX, upperY + distance, 0.0f), Quaternion.identity);
			upperY += distance;
		}
	}
	
	void Update () {
		var newY = Mathf.Max (target.position.y, boundsBottom);
		if(newY > boundsBottom ){
			transform.position = new Vector3 (transform.position.x, newY, transform.position.z);
		
			boundsBottom = newY;

			var platforms = GameObject.FindGameObjectsWithTag ("Platform");

			foreach(var p in platforms){
				if(p.transform.position.y < boundsBottom - 7.5f){
					var newX = Random.Range (1000, 2258) / 1000.0f;
					upperY += distance;
					p.transform.position = new Vector3 (newX, upperY, 0.0f);
					p.GetComponent<TouchesPlatform> ().counted = false;
				}
			}

		}

		PlatformCounterText.text = platformCounter.ToString();
	}
}
