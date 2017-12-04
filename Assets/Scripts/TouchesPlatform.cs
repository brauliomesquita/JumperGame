using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchesPlatform : MonoBehaviour {

	public bool touched = false;

	void OnCollisionEnter2D(Collision2D target){
		
		Debug.Log (target.otherCollider.gameObject.transform.position.y);
		if(!touched){
			var platforms = GameObject.FindGameObjectsWithTag ("Platform");

			foreach(var p in platforms){
				if(p.gameObject.GetInstanceID() == target.otherCollider.gameObject.GetInstanceID())
					continue;

				Debug.Log ("target.otherCollider.gameObject.transform.position.y: " + target.otherCollider.gameObject.transform.position.y);
				Debug.Log ("p.transform.position.y: " + p.transform.position.y);

				if(p.transform.position.y < target.otherCollider.gameObject.transform.position.y){
					var newX = Random.Range (1000, 2258) / 1000.0f;
					var newY = p.transform.position.y + 4.5f;
					p.transform.position = new Vector3 (newX, newY, 0.0f);
					p.GetComponent<TouchesPlatform> ().touched = false;
				}
			}

			// Contador
		}
		
		touched = true;
	}

}
