using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {

	public Sprite[] heads;
	public Sprite[] polos;

	SpriteRenderer head;
	SpriteRenderer polo;

	void Awake() {
		head = (transform.FindChild("skelet/head")).GetComponentInChildren<SpriteRenderer> ();
		polo = (transform.FindChild("skelet/body")).GetComponentInChildren<SpriteRenderer> ();
	}
	public int h, p;
	public void genRandom(){
		h = Random.Range (0, heads.Length);
		p = Random.Range (0, polos.Length);
		head.sprite = heads [h];
		polo.sprite = polos [p];
	}
}
