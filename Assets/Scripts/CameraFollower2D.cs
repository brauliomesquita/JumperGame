using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower2D : MonoBehaviour {

	private Transform target;

	public float boundsBottom = 0.0f;

	public Vector2 movementFromBase = new Vector2 (0.0f, 0.0f);
	public Vector2 baseLocation = new Vector2(0.0f, 0.0f);

	void Start () {
		target = GameObject.FindWithTag ("Player").transform;

		baseLocation = new Vector2 (transform.position.x, transform.position.y);
	}
	
	void Update () {
		transform.position = new Vector3 (transform.position.x, Mathf.Max(target.position.y, boundsBottom), transform.position.z);
		movementFromBase = new Vector2 (transform.position.x - baseLocation.x, transform.position.y - baseLocation.y);
	}
}
