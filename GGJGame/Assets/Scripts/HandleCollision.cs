using UnityEngine;
using System.Collections;

public class HandleCollision : MonoBehaviour {

	public bool collisionTrigered = false;

	void OnTriggerEnter2D(Collider2D other) {
		collisionTrigered = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		collisionTrigered = false;
	}
}
