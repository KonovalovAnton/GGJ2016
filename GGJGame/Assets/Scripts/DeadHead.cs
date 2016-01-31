using UnityEngine;
using System.Collections;

public class DeadHead : MonoBehaviour {

	Rigidbody2D rgb;

	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody2D>();
		int force = Random.Range (50, 500);
		int rotator = Random.Range (50, 500);
		rgb.AddForce(Vector2.left * force);
		rgb.angularVelocity = rotator;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
