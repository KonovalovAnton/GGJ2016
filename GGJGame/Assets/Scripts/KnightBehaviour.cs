using UnityEngine;
using System.Collections;

public class KnightBehaviour : MonoBehaviour {

	public GameObject deadHead;
	public ParticleSystem blood;


	public enum State
	{
		Spawned,
		Running,
		Knees,
		Throne,
		Disable,
		Exit
	}

	public State st;
	public HandleCollision kneePoint,thronePoint,exitPoint;
	public Transform spawnPoint;
	public Animator anim;
	public ControllerScript cs;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator>();
		king = GameObject.Find ("King").GetComponentInChildren<Animator> ();
		st = State.Spawned;
		head = gameObject.transform.Find("skelet/head").GetComponent<SpriteRenderer>();

	}

	void OnAwake() {
		//blood.Stop();
		blood.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		print("BLood is playing: " + blood.isPlaying);
		switch (st) {
		case State.Spawned:
			spawn ();
			break;
		case State.Running:
			run ();
			break;
		case State.Knees:
			knees ();
			break;
		case State.Throne:
			throne ();
			break;
		case State.Disable:
			gameObject.SetActive(false);
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
		anim.SetTrigger ("RUN");
		transform.Translate (delta);
		if (kneePoint.collisionTrigered) {
			st = State.Knees;
			cs.SetKnightReady ();
		}
	}


	Animator king;
	void knees() {
		anim.ResetTrigger ("RUN");
		anim.SetTrigger ("KNEES");
		king.ResetTrigger ("STAY");
		king.SetTrigger ("KNIGHTING");
	}

	void throne() {
		anim.ResetTrigger ("KNEES");
		anim.SetTrigger ("RUN");
		transform.Translate (deltaThrone);
		if (thronePoint.collisionTrigered) {
			st = State.Exit;
		}
	}

	void exit() {
		transform.Translate (delta);
		if (exitPoint.collisionTrigered) {
			st = State.Spawned;
			if(noHead) {
				//blood.Stop();
				blood.gameObject.SetActive(false);
				xorHead();
			}
		}
	}

	public void setKneesOff(bool cutHead) {
		st = State.Throne;
		king.ResetTrigger ("KNIGHTING");
		king.SetTrigger ("STAY");
		if(cutHead) {
			blood.gameObject.SetActive(true);
			Instantiate(deadHead, head.transform.position, Quaternion.identity);
			xorHead();
		}
	}

	public bool noHead = false;
	SpriteRenderer head;
	public void xorHead() {
		head.enabled = noHead;
		noHead ^= true;
	}
}
