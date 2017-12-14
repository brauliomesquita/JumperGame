using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameAtTouch : MonoBehaviour {

	public void OnTriggerExit2D (Collider2D target) {
		if (target.gameObject.tag == "Player") {
			SceneManager.LoadScene("Menu");
		}
	}
}
