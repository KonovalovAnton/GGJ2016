using UnityEngine;
using System.Collections;

public class HandleCollision : MonoBehaviour {

	public bool collisionTrigered = false;
    
	void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
		collisionTrigered = true;
	}
    
    void OnTriggerExit2D(Collider2D other) {
		collisionTrigered = false;
	}

    /*
    void OnTriggerStay2D(Collider2D other)
    {
        collisionTrigered = true;
    }*/
}
