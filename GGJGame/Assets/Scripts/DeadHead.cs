using UnityEngine;
using System.Collections;

public class DeadHead : MonoBehaviour {

	Rigidbody2D rgb;

	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody2D>();
		rgb.AddForce(Vector2.right * 500);
		rgb.angularVelocity = 250;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
