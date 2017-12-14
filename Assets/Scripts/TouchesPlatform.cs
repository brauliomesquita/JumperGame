using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchesPlatform : MonoBehaviour {

	public bool counted = false;

	void OnCollisionEnter2D(Collision2D target){

		if (target.gameObject.tag == "Player") {
			if (!counted) {
				//if (target.gameObject.GetComponent<Rigidbody2D> ().velocity.y <= 0.01) {
					GameObject.FindWithTag ("MainCamera").GetComponent<CameraFollower2D> ().platformCounter++;
				//}
			}

			counted = true;
		}
	}

}
