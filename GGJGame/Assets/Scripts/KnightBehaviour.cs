using UnityEngine;
using System.Collections;

public class KnightBehaviour : MonoBehaviour {


	public enum State
	{
		Spawned,
		Running,
		Knees,
		Throne,
		Exit
	}

	public State st;
	public HandleCollision kneePoint,thronePoint,exitPoint;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		st = State.Spawned;
	}
	
	// Update is called once per frame
	void Update () {
		switch (st) {
		case State.Spawned:
			spawn ();
			break;
		case State.Running:
			run ();
			break;
		case State.Knees:
			break;
		case State.Throne:
			throne ();
			break;
		case State.Exit:
			exit ();
			break;
		}
	}

	void spawn() {
		transform.position = spawnPoint.transform.position;
		st = State.Running;
	}

	//bool came = false;
	Vector3 delta = new Vector3(0.1f,0,0);
	Vector3 deltaThrone = new Vector3(0.1f,-0.1f,0);

	void run() {
		transform.Translate (delta);
		if (kneePoint.collisionTrigered) {
			st = State.Knees;
		}
	}

	void throne() {
		transform.Translate (deltaThrone);
		if (thronePoint.collisionTrigered) {
			st = State.Exit;
		}
	}

	void exit() {
		transform.Translate (delta);
		if (exitPoint.collisionTrigered) {
			st = State.Spawned;
		}
	}
}
