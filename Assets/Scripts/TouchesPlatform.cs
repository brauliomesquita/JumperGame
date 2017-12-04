using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchesPlatform : MonoBehaviour {

	public bool touched = false;

	void OnCollisionEnter2D(Collision2D target){
		
		if(!touched){
			var platforms = GameObject.FindGameObjectsWithTag ("Platform");
			foreach(var p in platforms){
				if(p == target.gameObject)
					continue;
				Debug.Log("Aqui");
				Debug.Log(p.transform.position.x);
				if(p.transform.position.y < target.gameObject.transform.position.y){
					var newY = target.gameObject.transform.position.y + 6.0f;
					target.gameObject.transform.position = new Vector3 (target.gameObject.transform.position.x, newY, 0.0f);
				}
			}
		}
		
		touched = true;
		
	}

}
